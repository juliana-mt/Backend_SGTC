using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface ICursoRepository
    {
        Task<Curso> CreateAsync(Curso curso);
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> ObterPorIdAsync(int id);
    }
}
