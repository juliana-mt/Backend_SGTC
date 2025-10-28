using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface ICertificadoService
    {
        Certificado EmitirCertificado(int idUsuario, int idCurso);
        IEnumerable<Certificado> ObterPorUsuario(int idUsuario);
        Certificado ObterPorCodigo(string codigo);
    }
}
