using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IProgressoCursoService
    {
        Task<bool> MarcarConclusaoAsync(MarcarProgressoDto dto);
        Task<IEnumerable<ProgressoCursoDto>> ListarPorUsuarioAsync(int idUsuario);
        Task<ProgressoDetalhadoDto> CalcularProgressoAsync(int idUsuario, int idCurso);
    }
}
