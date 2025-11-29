using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICertificateService
    {
        Task<CertificateDTO> GerarAsync(CreateCertificateDTO dto);
        Task<IEnumerable<CertificateDTO>> ListarPorUsuarioAsync(int usuarioId);
        Task<CertificateDTO?> BuscarPorIdAsync(int id);
        byte[] GerarPDF(CertificateDTO dto);
        Task<CertificateDTO?> GerarAutomaticoAsync(int usuarioId, int idCurso);
    }

}
