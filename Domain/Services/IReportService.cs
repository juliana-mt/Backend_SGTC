using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IReportService
    {
        Task<IEnumerable<UserReportDTO>> GenerateByUserAsync(int usuarioId);
        Task<IEnumerable<CourseReportDTO>> GenerateByCourseAsync(int cursoId);
    }
}
