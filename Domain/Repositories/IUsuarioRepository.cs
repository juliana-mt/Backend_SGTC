using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario> AtualizarAsync(Usuario usuario);
        Task<bool> DesativarAsync(int id);
    }
}
