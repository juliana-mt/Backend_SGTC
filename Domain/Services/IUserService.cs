using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);  // <- adiciona o ?
        Task<UserDTO> CreateAsync(CreateUserDTO dto);
        Task<bool> UpdateAsync(int id, UpdateUserDTO dto);
        Task<bool> DisableAsync(int id);
        Task ActivateUserAsync(int id);
        Task DisableAsyncUser(int id);
    }
}
