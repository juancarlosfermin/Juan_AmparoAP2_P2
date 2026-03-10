using Juan_AmparoAP2_P2.DAL;
using Juan_AmparoAP2_P2.Models;
using Microsoft.EntityFrameworkCore;
using Juan_AmparoAP2_P2.Services;

namespace Juan_AmparoAP2_P2.Services
{
    public class AsignacionesServices
    {
        private readonly Contexto _contexto;

        public AsignacionesServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(AsignacionesPuntos asignacion)
        {
            if (asignacion.IdAsignacion == 0)
                return await Insertar(asignacion);
            else
                return await Modificar(asignacion);
        }

        private async Task<bool> Insertar(AsignacionesPuntos asignacion)
        {
            _contexto.AsignacionesPuntos.Add(asignacion);

            var estudiante = await _contexto.Estudiantes.FindAsync(asignacion.EstudianteId);
            if (estudiante != null)
            {
                estudiante.BalancePuntos += asignacion.TotalPuntos;
            }

            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(AsignacionesPuntos asignacion)
        {
            var asignacionExistente = await _contexto.AsignacionesPuntos
                .Include(a => a.AsignacionesDetalle)
                .FirstOrDefaultAsync(a => a.IdAsignacion == asignacion.IdAsignacion);

            if (asignacionExistente != null)
            {
                var estudianteAnterior = await _contexto.Estudiantes.FindAsync(asignacionExistente.EstudianteId);
                if (estudianteAnterior != null)
                {
                    estudianteAnterior.BalancePuntos -= asignacionExistente.TotalPuntos;
                }

                _contexto.AsignacionesPuntosDetalle.RemoveRange(asignacionExistente.AsignacionesDetalle);

                asignacionExistente.EstudianteId = asignacion.EstudianteId;
                asignacionExistente.TotalPuntos = asignacion.TotalPuntos;

                asignacionExistente.AsignacionesDetalle = asignacion.AsignacionesDetalle.Select(d => new AsignacionesPuntosDetalle
                {
                    TipoPuntoId = d.TipoPuntoId,
                    CantidadPuntos = d.CantidadPuntos
                }).ToList();

                var estudianteNuevo = await _contexto.Estudiantes.FindAsync(asignacionExistente.EstudianteId);
                if (estudianteNuevo != null)
                {
                    estudianteNuevo.BalancePuntos += asignacionExistente.TotalPuntos;
                }
                return await _contexto.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> Eliminar(int id)
        {
            var asignacion = await _contexto.AsignacionesPuntos
                .Include(a => a.AsignacionesDetalle)
                .FirstOrDefaultAsync(a => a.IdAsignacion == id);

            if (asignacion != null)
            {
                var estudiante = await _contexto.Estudiantes.FindAsync(asignacion.EstudianteId);
                if (estudiante != null)
                {
                    estudiante.BalancePuntos -= asignacion.TotalPuntos;
                }

                _contexto.AsignacionesPuntos.Remove(asignacion);
                return await _contexto.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<AsignacionesPuntos?> Buscar(int id)
        {
            return await _contexto.AsignacionesPuntos
                .Include(a => a.AsignacionesDetalle)
                .FirstOrDefaultAsync(a => a.IdAsignacion == id);
        }

        public async Task<List<AsignacionesPuntos>> ObtenerTodos()
        {
            return await _contexto.AsignacionesPuntos
                .Include(a => a.Estudiante)
                .Include(a => a.AsignacionesDetalle)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}