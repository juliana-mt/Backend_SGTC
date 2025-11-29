using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }


        // Mudança: Assinatura conforme interface (recebe Usuario)
        public async Task<UserDTO> CreateAsync(CreateUserDTO dto)
        {
            var usuario = new User(dto.Nome, dto.Email, dto.Cargo, dto.Senha);
            var criado = await _usuarioRepository.CreateAsync(usuario);

            return new UserDTO
            {
                Id = criado.Id,
                Nome = criado.Name,
                Email = criado.Email,
                Cargo = criado.Position,
                Ativo = criado.Active
            };
        }


        // Mudança: Método para desativar usuário (implementação baseada no método DeletarAsync)
        public async Task<bool> DisableAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            usuario.Disable();
            await _usuarioRepository.UpdateAsync(usuario);
            return true;
        }

        public async Task ActivateUserAsync(int id)
        {
            await _usuarioRepository.ActiveUserAsync(id);
        }

        public async Task DisableAsyncUser(int id)
        {
            await _usuarioRepository.DisableUserAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDTO dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            var nome = dto.Nome ?? usuario.Name;
            var cargo = dto.Cargo ?? usuario.Position;

            usuario.Update(nome, dto.Email, cargo);

            await _usuarioRepository.UpdateAsync(usuario);
            return true;
        }

    }
}
