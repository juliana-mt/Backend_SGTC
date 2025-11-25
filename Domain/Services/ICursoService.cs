using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICursoService
    {
        Task<Curso> CreateAsync(CreateCursoDTO dto);
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> ObterPorIdAsync(int id);
    }
}
