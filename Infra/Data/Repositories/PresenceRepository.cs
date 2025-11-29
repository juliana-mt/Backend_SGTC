using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class PresenceRepository : IPresenceRepository
    {
        private readonly DataContext _context;

        public PresenceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Presence> CriarAsync(Presence presenca)
        {
            _context.Presencas.Add(presenca);
            await _context.SaveChangesAsync();
            return presenca;
        }

        public async Task<IEnumerable<Presence>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _context.Presencas
                                 .Where(p => p.IdUser == idUsuario)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Presence>> ObterPorCursoAsync(int idCurso)
        {
            return await _context.Presencas
                                 .Where(p => p.IdCourse == idCurso)
                                 .ToListAsync();
        }
    }
}
