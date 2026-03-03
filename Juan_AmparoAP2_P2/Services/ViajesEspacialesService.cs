using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Juan_AmparoAP2_P2.Models;
using Juan_AmparoAP2_P2.DAL;

namespace Juan_AmparoAP2_P2.Services
{
    public class ViajesEspacialesService
    {
        private readonly Contexto _contexto;

        public ViajesEspacialesService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int id)
        {
            return false;
        }

        private async Task<bool> Insertar(ViajesEspaciales viaje)
        {
            return false;
        }

        private async Task<bool> Modificar(ViajesEspaciales viaje)
        {
            return false;
        }

        public async Task<bool> Guardar(ViajesEspaciales viaje)
        {
            return false;
        }

        public async Task<bool> Eliminar(int id)
        {
            return false;
        }

        public async Task<ViajesEspaciales?> Buscar(int id)
        {
            return null;
        }

        //public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
        //{
        //    return await _contexto.ViajesEspaciales
        //        .AsNoTracking()
        //        .Where(criterio)
        //        .ToListAsync();
        //}
    }
}