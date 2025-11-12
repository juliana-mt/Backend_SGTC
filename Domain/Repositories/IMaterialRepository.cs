using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IMaterialRepository
    {
        Task<Material> CreateAsync(Material material);
        Task<Material?> GetByIdAsync(int id);
        Task<IEnumerable<Material>> GetByCursoAsync(int cursoId);
    }
}
