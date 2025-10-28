using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IAvaliacaoService
    {
        IEnumerable<Avaliacao> ObterPorCurso(int idCurso);
        void RegistrarAvaliacao(Avaliacao avaliacao);
        void AtualizarAvaliacao(Avaliacao avaliacao);
        double CalcularMediaCurso(int idCurso);
    }
}
