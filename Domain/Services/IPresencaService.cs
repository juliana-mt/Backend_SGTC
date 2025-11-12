using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IPresencaService
    {
        Task<PresencaDto> RegistrarAsync(CreatePresencaDto dto);
        Task<IEnumerable<PresencaDto>> ListarPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<PresencaDto>> ListarPorCursoAsync(int idCurso);
    }
}
