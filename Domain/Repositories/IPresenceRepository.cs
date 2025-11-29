using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IPresenceRepository
    {
        Task<Presence> CriarAsync(Presence presenca);
        Task<IEnumerable<Presence>> ObterPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Presence>> ObterPorCursoAsync(int idCurso);
    }
}
