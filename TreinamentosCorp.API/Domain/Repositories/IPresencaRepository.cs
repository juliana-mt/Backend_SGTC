using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IPresencaRepository
    {
        Presenca ObterPorId(int id);
        IEnumerable<Presenca> ObterPorCurso(int idCurso);
        void RegistrarPresenca(Presenca presenca);
        void AtualizarPresenca(Presenca presenca);
    }
}
