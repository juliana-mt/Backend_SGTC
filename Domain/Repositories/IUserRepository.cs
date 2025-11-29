using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User usuario);
        Task<User> UpdateAsync(User usuario);
        Task<bool> DisableUserAsync(int id);
        Task ActiveUserAsync(int id);
        Task<User?> GetByEmailAsync(string email);
    }
}
