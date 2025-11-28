using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IAvaliacaoService
    {
        Task<AvaliacaoDTO> CreateAsync(CreateAvaliacaoDto dto);
        Task<AvaliacaoDTO?> GetByIdAsync(int id);
        Task<ResultadoAvaliacaoDto?> SubmitAsync(int avaliacaoId, SubmeterAvaliacaoDto dto);
        Task<IEnumerable<ResultadoAvaliacaoDto>> GetResultadosByUsuarioAsync(int usuarioId);
    }
}
