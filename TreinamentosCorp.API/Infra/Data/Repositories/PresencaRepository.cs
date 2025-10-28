using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly List<Presenca> _presencas = new();

        public Presenca ObterPorId(int id) => _presencas.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Presenca> ObterPorCurso(int idCurso) => _presencas.Where(p => p.IdCurso == idCurso);

        public void RegistrarPresenca(Presenca presenca)
        {
            presenca.GetType().GetProperty("Id")?.SetValue(presenca, _presencas.Count + 1);
            _presencas.Add(presenca);
        }

        public void AtualizarPresenca(Presenca presenca)
        {
            var existente = ObterPorId(presenca.Id);
            if (existente != null)
            {
                _presencas.Remove(existente);
                _presencas.Add(presenca);
            }
        }
    }
}
