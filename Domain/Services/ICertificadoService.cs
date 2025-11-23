using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICertificadoService
    {
        Task<CertificadoDTO> GerarAsync(CreateCertificadoDTO dto);
        Task<IEnumerable<CertificadoDTO>> ListarPorUsuarioAsync(int usuarioId);
        Task<CertificadoDTO?> BuscarPorIdAsync(int id);
        byte[] GerarPDF(CertificadoDTO dto);
        Task<CertificadoDTO?> GerarAutomaticoAsync(int usuarioId, int idCurso);
    }

}
