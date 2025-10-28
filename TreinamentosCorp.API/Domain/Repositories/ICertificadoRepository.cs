using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface ICertificadoRepository
    {
        void Emitir(Certificado certificado);
        IEnumerable<Certificado> ObterPorUsuario(int idUsuario);
        Certificado ObterPorCodigo(string codigo);
    }
}
