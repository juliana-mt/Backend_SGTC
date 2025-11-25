using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario?> ObterPorIdAsync(int id);  // <- adiciona o ?
        Task<UsuarioDTO> CriarAsync(CreateUsuarioDto dto);
        Task<bool> AtualizarAsync(int id, UpdateUsuarioDto dto);
        Task<bool> DesativarAsync(int id);
        Task AtivarUsuarioAsync(int id);
        Task DesativarUsuarioAsync(int id);
    }
}
