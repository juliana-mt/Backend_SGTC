using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IPresenceService
    {
        Task<PresenceDTO> RegistrarAsync(CreatePresenceDTO dto);
        Task<IEnumerable<PresenceDTO>> ListarPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<PresenceDTO>> ListarPorCursoAsync(int idCurso);
    }
}
