using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Servicess
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObterTodos() => _usuarioRepository.ObterTodos();

        public Usuario ObterPorId(int id) => _usuarioRepository.ObterPorId(id);

        public void Criar(Usuario usuario) => _usuarioRepository.Criar(usuario);

        public void Atualizar(Usuario usuario) => _usuarioRepository.Atualizar(usuario);

        public void Desativar(int id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);
            if (usuario != null)
            {
                usuario.Desativar();
                _usuarioRepository.Atualizar(usuario);
            }
        }
    }
}
