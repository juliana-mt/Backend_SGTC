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

        // Mudança: Assinatura conforme interface (recebe Usuario)
        public async Task CriarAsync(Usuario usuario)
        {
            await _usuarioRepository.CreateAsync(usuario);
        }

        // Mudança: Assinatura conforme interface (recebe Usuario)
        public async Task AtualizarAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        // Mudança: Método para desativar usuário (implementação baseada no método DeletarAsync)
        public async Task<bool> DesativarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            usuario.Ativo = false; // Exemplo para desativar
            await _usuarioRepository.UpdateAsync(usuario);
            return true;
        }
    }
}
