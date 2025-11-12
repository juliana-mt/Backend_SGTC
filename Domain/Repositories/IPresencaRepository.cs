using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IPresencaRepository
    {
        Task<Presenca> CriarAsync(Presenca presenca);
        Task<IEnumerable<Presenca>> ObterPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Presenca>> ObterPorCursoAsync(int idCurso);
    }
}
