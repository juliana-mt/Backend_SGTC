using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface ICertificadoRepository
    {
        Task<Certificado> CreateAsync(Certificado certificado);
        Task<IEnumerable<Certificado>> GetByUsuarioAsync(int usuarioId);
        Task<Certificado?> GetByIdAsync(int id);
        Task<Certificado?> GetByUsuarioCursoAsync(int usuarioId, int cursoId);
    }
}
