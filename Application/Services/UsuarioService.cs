using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> CriarAsync(string nome, string email, string cargo, string senhaHash)
        {
            var usuario = new Usuario(nome, email, cargo, senhaHash);
            await _usuarioRepository.CreateAsync(usuario);
            return usuario;
        }

        public async Task<Usuario?> AtualizarAsync(int id, string nome, string email, string cargo)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return null;

            usuario.Atualizar(nome, email, cargo);
            await _usuarioRepository.UpdateAsync(usuario);

            return usuario;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            await _usuarioRepository.DeleteAsync(id);
            return true;
        }
    }
}
