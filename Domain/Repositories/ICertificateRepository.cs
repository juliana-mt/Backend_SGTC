using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface ICertificateRepository
    {
        Task<Certificate> CreateAsync(Certificate certificado);
        Task<IEnumerable<Certificate>> GetByUserAsync(int usuarioId);
        Task<Certificate?> GetByIdAsync(int id);
        Task<Certificate?> GetByUserCourseAsync(int usuarioId, int cursoId);
    }
}
