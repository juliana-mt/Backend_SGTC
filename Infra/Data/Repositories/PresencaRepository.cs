using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly DataContext _context;

        public PresencaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Presenca> CriarAsync(Presenca presenca)
        {
            _context.Presencas.Add(presenca);
            await _context.SaveChangesAsync();
            return presenca;
        }

        public async Task<IEnumerable<Presenca>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _context.Presencas
                                 .Where(p => p.IdUsuario == idUsuario)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Presenca>> ObterPorCursoAsync(int idCurso)
        {
            return await _context.Presencas
                                 .Where(p => p.IdCurso == idCurso)
                                 .ToListAsync();
        }
    }
}
