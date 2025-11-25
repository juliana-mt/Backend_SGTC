using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using System.Linq;

namespace TreinamentosCorp.API.Application.Services
{
    public class ProgressoCursoService : IProgressoCursoService
    {
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IModuloRepository _moduloRepository;

        public ProgressoCursoService(IProgressoCursoRepository progressoRepository, IModuloRepository moduloRepository)
        {
            _progressoRepository = progressoRepository;
            _moduloRepository = moduloRepository;
        }

        public async Task<bool> MarcarConclusaoAsync(MarcarProgressoDto dto)
        {
            if (await _progressoRepository.ExisteAsync(dto.IdUsuario, dto.IdModulo))
                return false;

            var progresso = new ProgressoCurso(dto.IdUsuario, dto.IdModulo, dto.IdCurso);
            await _progressoRepository.RegistrarAsync(progresso);

            return true;
        }

        public async Task<IEnumerable<ProgressoCursoDto>> ListarPorUsuarioAsync(int idUsuario)
        {
            var lista = await _progressoRepository.ListarPorUsuarioAsync(idUsuario);

            return lista.Select(p => new ProgressoCursoDto
            {
                Id = p.Id,
                IdUsuario = p.IdUsuario,
                IdModulo = p.IdModulo,
                DataConclusao = p.DataConclusao
            });
        }

        public async Task<ProgressoDetalhadoDTO> CalcularProgressoAsync(int idUsuario, int idCurso)
        {
            var modulos = await _moduloRepository.ListarPorCursoAsync(idCurso);
            int totalModulos = modulos.Count();

            if (totalModulos == 0)
            {
                return new ProgressoDetalhadoDTO
                {
                    IdCurso = idCurso,
                    TotalModulos = 0,
                    ModulosConcluidos = 0,
                    Porcentagem = 0
                };
            }

            // Buscar progresso do usuário
            var progresso = await _progressoRepository.ListarPorUsuarioAsync(idUsuario);

            int concluidos = progresso
                .Count(p => modulos.Any(m => m.Id == p.IdModulo));

            // Calcular %
            int porcentagem = (int)((double)concluidos / totalModulos * 100);

            return new ProgressoDetalhadoDTO
            {
                IdCurso = idCurso,
                TotalModulos = totalModulos,
                ModulosConcluidos = concluidos,
                Porcentagem = porcentagem
            };
        }

    }
}
