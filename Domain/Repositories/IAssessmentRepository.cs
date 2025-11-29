using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IAssessmentRepository
    {
        Task<Assessment> CreateAsync(Assessment avaliacao);
        Task<Assessment?> GetByIdAsync(int id);
        Task<AssessmentResultsDTO?> SubmitAsync(int avaliacaoId, SubmitAssessmentDTO dto);
        Task<IEnumerable<AssessmentResultsDTO>> GetResultByUserAsync(int usuarioId);
        Task<int?> GetFinalNoteAsync(int usuarioId, int cursoId);
    }
}
