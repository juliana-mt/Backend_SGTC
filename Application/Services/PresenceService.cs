using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class PresenceService : IPresenceService
    {
        private readonly IPresenceRepository _repository;

        public PresenceService(IPresenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<PresenceDTO> RegistrarAsync(CreatePresenceDTO dto)
        {
            var presenca = new Presence(dto.IdUsuario, dto.IdCurso, dto.DataPresenca, dto.Presente);
            var criada = await _repository.CriarAsync(presenca);

            return new PresenceDTO
            {
                Id = criada.Id,
                IdUsuario = criada.IdUser,
                IdCurso = criada.IdCourse,
                Data = criada.Date,
                Presente = criada.Present
            };
        }

        public async Task<IEnumerable<PresenceDTO>> ListarPorUsuarioAsync(int idUsuario)
        {
            var presencas = await _repository.ObterPorUsuarioAsync(idUsuario);
            return presencas.Select(p => new PresenceDTO
            {
                Id = p.Id,
                IdUsuario = p.IdUser,
                IdCurso = p.IdCourse,
                Data = p.Date,
                Presente = p.Present
            });
        }

        public async Task<IEnumerable<PresenceDTO>> ListarPorCursoAsync(int idCurso)
        {
            var presencas = await _repository.ObterPorCursoAsync(idCurso);
            return presencas.Select(p => new PresenceDTO
            {
                Id = p.Id,
                IdUsuario = p.IdUser,
                IdCurso = p.IdCourse,
                Data = p.Date,
                Presente = p.Present
            });
        }
    }
}
