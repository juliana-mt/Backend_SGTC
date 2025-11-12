using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IModuloService
    {
        Task<ModuloDto> CriarAsync(CreateModuloDto dto, string caminhoArquivo);
        Task<IEnumerable<ModuloDto>> ListarPorCursoAsync(int idCurso);
        Task<ModuloDto?> GetByIdAsync(int id);
    }
}
