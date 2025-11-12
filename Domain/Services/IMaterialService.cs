using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IMaterialService
    {
        Task<MaterialDTO> CreateAsync(CreateMaterialDTO dto);
        Task<IEnumerable<MaterialDTO>> GetAllAsync();
        Task<MaterialDTO?> GetByIdAsync(int id);
    }
}
