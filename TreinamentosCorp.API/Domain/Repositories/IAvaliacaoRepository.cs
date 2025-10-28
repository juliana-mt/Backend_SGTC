using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IAvaliacaoRepository
    {
        Avaliacao ObterPorId(int id);
        IEnumerable<Avaliacao> ObterPorCurso(int idCurso);
        void Registrar(Avaliacao avaliacao);
        void Atualizar(Avaliacao avaliacao);
    }
}
