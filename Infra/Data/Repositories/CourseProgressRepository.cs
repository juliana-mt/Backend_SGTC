using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class CourseProgressRepository : IProgressoCursoRepository
    {
        private readonly DataContext _context;

        public CourseProgressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(CourseProgress progresso)
        {
            _context.ProgressoCursos.Add(progresso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int idUsuario, int idModulo)
        {
            return await _context.ProgressoCursos
                .AnyAsync(p => p.IdUser == idUsuario && p.IdModule == idModulo);
        }

        public async Task<IEnumerable<CourseProgress>> ListByUserAsync(int idUsuario)
        {
            return await _context.ProgressoCursos
                .Where(p => p.IdUser == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseProgress>> ListByCourseAsync(int idCurso)
        {
            return await _context.ProgressoCursos
                .Where(p => p.IdCourse == idCurso)
                .ToListAsync();
        }

    }
}
