using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Services
{
    public interface IPresencaService
    {
        IEnumerable<Presenca> ObterPorCurso(int idCurso);
        void RegistrarPresenca(Presenca presenca);
        void AtualizarPresenca(int id, bool presente);
    }
}
