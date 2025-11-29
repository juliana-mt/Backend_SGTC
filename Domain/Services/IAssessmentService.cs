using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IAssessmentService
    {
        Task<AssessmentDTO> CreateAsync(CreateAssessmentDTO dto);
        Task<AssessmentDTO?> GetByIdAsync(int id);
        Task<AssessmentResultsDTO?> SubmitAsync(int avaliacaoId, SubmitAssessmentDTO dto);
        Task<IEnumerable<AssessmentResultsDTO>> GetResultadosByUsuarioAsync(int usuarioId);
    }
}
