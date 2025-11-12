using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class PresencaService : IPresencaService
    {
        private readonly IPresencaRepository _repository;

        public PresencaService(IPresencaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PresencaDto> RegistrarAsync(CreatePresencaDto dto)
        {
            var presenca = new Presenca(dto.IdUsuario, dto.IdCurso, dto.Data, dto.Presente);
            var criada = await _repository.CriarAsync(presenca);

            return new PresencaDto
            {
                Id = criada.Id,
                IdUsuario = criada.IdUsuario,
                IdCurso = criada.IdCurso,
                Data = criada.Data,
                Presente = criada.Presente
            };
        }

        public async Task<IEnumerable<PresencaDto>> ListarPorUsuarioAsync(int idUsuario)
        {
            var presencas = await _repository.ObterPorUsuarioAsync(idUsuario);
            return presencas.Select(p => new PresencaDto
            {
                Id = p.Id,
                IdUsuario = p.IdUsuario,
                IdCurso = p.IdCurso,
                Data = p.Data,
                Presente = p.Presente
            });
        }

        public async Task<IEnumerable<PresencaDto>> ListarPorCursoAsync(int idCurso)
        {
            var presencas = await _repository.ObterPorCursoAsync(idCurso);
            return presencas.Select(p => new PresencaDto
            {
                Id = p.Id,
                IdUsuario = p.IdUsuario,
                IdCurso = p.IdCurso,
                Data = p.Data,
                Presente = p.Presente
            });
        }
    }
}
