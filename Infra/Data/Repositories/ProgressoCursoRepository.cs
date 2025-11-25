using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class ProgressoCursoRepository : IProgressoCursoRepository
    {
        private readonly DataContext _context;

        public ProgressoCursoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsync(ProgressoCurso progresso)
        {
            _context.ProgressoCursos.Add(progresso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(int idUsuario, int idModulo)
        {
            return await _context.ProgressoCursos
                .AnyAsync(p => p.IdUsuario == idUsuario && p.IdModulo == idModulo);
        }

        public async Task<IEnumerable<ProgressoCurso>> ListarPorUsuarioAsync(int idUsuario)
        {
            return await _context.ProgressoCursos
                .Where(p => p.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProgressoCurso>> ListarPorCursoAsync(int idCurso)
        {
            return await _context.ProgressoCursos
                .Where(p => p.IdCurso == idCurso)
                .ToListAsync();
        }

    }
}
