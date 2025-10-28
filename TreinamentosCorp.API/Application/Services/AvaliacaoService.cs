using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Servicess
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public IEnumerable<Avaliacao> ObterPorCurso(int idCurso) => _avaliacaoRepository.ObterPorCurso(idCurso);

        public void RegistrarAvaliacao(Avaliacao avaliacao) => _avaliacaoRepository.Registrar(avaliacao);

        public void AtualizarAvaliacao(Avaliacao avaliacao) => _avaliacaoRepository.Atualizar(avaliacao);

        public double CalcularMediaCurso(int idCurso)
        {
            var avaliacoes = _avaliacaoRepository.ObterPorCurso(idCurso);
            if (!avaliacoes.Any()) return 0;
            return avaliacoes.Average(a => a.Nota);
        }
    }
}
