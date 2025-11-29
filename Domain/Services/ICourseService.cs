using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICourseService
    {
        Task<Course> CreateAsync(CreateCourseDTO dto);
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
    }
}
