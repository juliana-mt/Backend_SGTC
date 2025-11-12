using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario?> ObterPorIdAsync(int id);
        Task CriarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task<bool> DesativarAsync(int id);
    }
}
