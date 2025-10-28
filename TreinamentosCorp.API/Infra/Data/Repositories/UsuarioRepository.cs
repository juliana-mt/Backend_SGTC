using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new();

        public IEnumerable<Usuario> ObterTodos() => _usuarios;

        public Usuario ObterPorId(int id) => _usuarios.FirstOrDefault(u => u.Id == id);

        public void Criar(Usuario usuario)
        {
            usuario.GetType().GetProperty("Id")?.SetValue(usuario, _usuarios.Count + 1);
            _usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            var existente = ObterPorId(usuario.Id);
            if (existente != null)
            {
                _usuarios.Remove(existente);
                _usuarios.Add(usuario);
            }
        }

        public void Deletar(int id)
        {
            var usuario = ObterPorId(id);
            if (usuario != null) _usuarios.Remove(usuario);
        }
    }
}
