using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class CertificadoRepository : ICertificadoRepository
    {
        private readonly List<Certificado> _certificados = new();

        public void Emitir(Certificado certificado)
        {
            certificado.GetType().GetProperty("Id")?.SetValue(certificado, _certificados.Count + 1);
            _certificados.Add(certificado);
        }

        public IEnumerable<Certificado> ObterPorUsuario(int idUsuario)
            => _certificados.Where(c => c.IdUsuario == idUsuario);

        public Certificado ObterPorCodigo(string codigo)
            => _certificados.FirstOrDefault(c => c.CodigoValidacao == codigo);
    }
}
