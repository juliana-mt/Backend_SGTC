using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly DataContext _context;

        public ModuloRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(Modulo modulo)
        {
            _context.Modulos.Add(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Modulo>> ListarPorCursoAsync(int idCurso)
        {
            return await _context.Modulos
                .Where(m => m.IdCurso == idCurso)
                .ToListAsync();
        }

        public async Task<Modulo?> ObterPorIdAsync(int id)
        {
            return await _context.Modulos.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
