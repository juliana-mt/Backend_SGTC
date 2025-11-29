using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IModuleRepository
    {
        Task CreateAsync(Module modulo);
        Task<IEnumerable<Module>> ListByCourseAsync(int idCurso);
        Task<Module?> GetByIdAsync(int id);
    }
}
