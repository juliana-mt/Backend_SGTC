using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorId(int id);
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(int id);
    }
}
