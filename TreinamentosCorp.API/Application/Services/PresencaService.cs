using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Servicess
{
    public class PresencaService : IPresencaService
    {
        private readonly IPresencaRepository _presencaRepository;

        public PresencaService(IPresencaRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        public IEnumerable<Presenca> ObterPorCurso(int idCurso) => _presencaRepository.ObterPorCurso(idCurso);

        public void RegistrarPresenca(Presenca presenca) => _presencaRepository.RegistrarPresenca(presenca);

        public void AtualizarPresenca(int id, bool presente)
        {
            var presenca = _presencaRepository.ObterPorId(id);
            if (presenca == null) return;

            if (presente) presenca.MarcarPresenca();
            else presenca.MarcarFalta();

            _presencaRepository.AtualizarPresenca(presenca);
        }
    }
}
