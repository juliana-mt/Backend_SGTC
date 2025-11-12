using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IModuloRepository
    {
        Task CriarAsync(Modulo modulo);
        Task<IEnumerable<Modulo>> ListarPorCursoAsync(int idCurso);
        Task<Modulo?> ObterPorIdAsync(int id);
    }
}
