using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IRelatorioService
    {
        Task<IEnumerable<RelatorioUsuarioDTO>> GerarPorUsuarioAsync(int usuarioId);
        Task<IEnumerable<RelatorioCursoDTO>> GerarPorCursoAsync(int cursoId);
    }
}
