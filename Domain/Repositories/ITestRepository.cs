using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> CreateAsync(Avaliacao avaliacao);
        Task<Avaliacao?> GetByIdAsync(int id);
        Task<ResultadoAvaliacaoDto?> SubmitAsync(int avaliacaoId, SubmeterAvaliacaoDto dto);
        Task<IEnumerable<ResultadoAvaliacaoDto>> GetResultadosByUsuarioAsync(int usuarioId);
        Task<int?> ObterNotaFinalAsync(int usuarioId, int cursoId);
    }
}
