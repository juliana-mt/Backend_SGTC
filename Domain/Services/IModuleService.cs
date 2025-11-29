using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IModuleService
    {
        Task<ModuleDTO> CriarAsync(CreateModuleDTO dto, string caminhoArquivo);
        Task<IEnumerable<ModuleDTO>> ListarPorCursoAsync(int idCurso);
        Task<ModuleDTO?> GetByIdAsync(int id);
    }
}
