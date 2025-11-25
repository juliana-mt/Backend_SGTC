using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

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
            return await _usuarioRepository.ObterTodosAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _usuarioRepository.ObterPorIdAsync(id);
        }


        // Mudança: Assinatura conforme interface (recebe Usuario)
        public async Task<UsuarioDTO> CriarAsync(CreateUsuarioDto dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email, dto.Cargo, dto.Senha);
            var criado = await _usuarioRepository.CriarAsync(usuario);

            return new UsuarioDTO
            {
                Id = criado.Id,
                Nome = criado.Nome,
                Email = criado.Email,
                Cargo = criado.Cargo,
                Ativo = criado.Ativo
            };
        }


        // Mudança: Método para desativar usuário (implementação baseada no método DeletarAsync)
        public async Task<bool> DesativarAsync(int id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return false;

            usuario.Desativar();
            await _usuarioRepository.AtualizarAsync(usuario);
            return true;
        }

        public async Task AtivarUsuarioAsync(int id)
        {
            await _usuarioRepository.AtivarUsuarioAsync(id);
        }

        public async Task DesativarUsuarioAsync(int id)
        {
            await _usuarioRepository.DesativarUsuarioAsync(id);
        }

        public async Task<bool> AtualizarAsync(int id, UpdateUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return false;

            var nome = dto.Nome ?? usuario.Nome;
            var cargo = dto.Cargo ?? usuario.Cargo;

            usuario.Atualizar(nome, dto.Email, cargo);

            await _usuarioRepository.AtualizarAsync(usuario);
            return true;
        }

    }
}
