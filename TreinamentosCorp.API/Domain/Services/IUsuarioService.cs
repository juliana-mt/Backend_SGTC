using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorId(int id);
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Desativar(int id);
    }
}
