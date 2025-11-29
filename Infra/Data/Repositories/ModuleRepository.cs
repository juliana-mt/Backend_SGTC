using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DataContext _context;

        public ModuleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Module modulo)
        {
            _context.Modulos.Add(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Module>> ListByCourseAsync(int idCurso)
        {
            return await _context.Modulos
                .Where(m => m.IdCourse == idCurso)
                .ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _context.Modulos.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
