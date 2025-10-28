using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Servicess
{
    public class CertificadoService : ICertificadoService
    {
        private readonly ICertificadoRepository _certificadoRepository;

        public CertificadoService(ICertificadoRepository certificadoRepository)
        {
            _certificadoRepository = certificadoRepository;
        }

        public Certificado EmitirCertificado(int idUsuario, int idCurso)
        {
            var certificado = new Certificado(idUsuario, idCurso);
            _certificadoRepository.Emitir(certificado);
            return certificado;
        }

        public IEnumerable<Certificado> ObterPorUsuario(int idUsuario)
            => _certificadoRepository.ObterPorUsuario(idUsuario);

        public Certificado ObterPorCodigo(string codigo)
            => _certificadoRepository.ObterPorCodigo(codigo);
    }
}
