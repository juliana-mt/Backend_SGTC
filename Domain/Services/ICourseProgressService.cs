using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICourseProgressService
    {
        Task<bool> MarcarConclusaoAsync(ProgressBrandDTO dto);
        Task<IEnumerable<CourseProgressDTO>> ListarPorUsuarioAsync(int idUsuario);
        Task<DetailedProgressDTO> CalcularProgressoAsync(int idUsuario, int idCurso);
    }
}
