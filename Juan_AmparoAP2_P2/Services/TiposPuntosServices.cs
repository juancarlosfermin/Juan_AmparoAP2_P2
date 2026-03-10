using Juan_AmparoAP2_P2.DAL;
using Juan_AmparoAP2_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Juan_AmparoAP2_P2.Services
{
    public class TiposPuntosServices
    {
        private readonly Contexto _contexto;
        public TiposPuntosServices(Contexto contexto) { _contexto = contexto; }

        public async Task<List<TiposPuntos>> ObtenerActivos()
        {
            return await _contexto.TiposPuntos.Where(t => t.Activo).AsNoTracking().ToListAsync();
        }

        public async Task<List<TiposPuntos>> ObtenerTodos()
        {
            return await _contexto.TiposPuntos.AsNoTracking().ToListAsync();
        }
    }
}