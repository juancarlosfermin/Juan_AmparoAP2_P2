using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Juan_AmparoAP2_P2.Models;
using Juan_AmparoAP2_P2.DAL;

namespace Juan_AmparoAP2_P2.Services
{
    public class estudiantesServices
    {
        private readonly Contexto _contexto;
        public estudiantesServices(Contexto contexto) { _contexto = contexto; }
        public async Task<List<Estudiantes>> ObtenerTodos()
        {
            return await _contexto.Estudiantes.AsNoTracking().ToListAsync();
        }
    }
}