using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly List<Avaliacao> _avaliacoes = new();

        public Avaliacao ObterPorId(int id) => _avaliacoes.FirstOrDefault(a => a.Id == id);

        public IEnumerable<Avaliacao> ObterPorCurso(int idCurso) => _avaliacoes.Where(a => a.IdCurso == idCurso);

        public void Registrar(Avaliacao avaliacao)
        {
            avaliacao.GetType().GetProperty("Id")?.SetValue(avaliacao, _avaliacoes.Count + 1);
            _avaliacoes.Add(avaliacao);
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            var existente = ObterPorId(avaliacao.Id);
            if (existente != null)
            {
                _avaliacoes.Remove(existente);
                _avaliacoes.Add(avaliacao);
            }
        }
    }
}
