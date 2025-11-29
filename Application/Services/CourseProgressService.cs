using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using System.Linq;

namespace TreinamentosCorp.API.Application.Services
{
    public class CourseProgressService : ICourseProgressService
    {
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IModuleRepository _moduloRepository;

        public CourseProgressService(IProgressoCursoRepository progressoRepository, IModuleRepository moduloRepository)
        {
            _progressoRepository = progressoRepository;
            _moduloRepository = moduloRepository;
        }

        public async Task<bool> MarcarConclusaoAsync(ProgressBrandDTO dto)
        {
            if (await _progressoRepository.ExistsAsync(dto.IdUsuario, dto.IdModulo))
                return false;

            var progresso = new CourseProgress(dto.IdUsuario, dto.IdModulo, dto.IdCurso);
            await _progressoRepository.RegisterAsync(progresso);

            return true;
        }

        public async Task<IEnumerable<CourseProgressDTO>> ListarPorUsuarioAsync(int idUsuario)
        {
            var lista = await _progressoRepository.ListByUserAsync(idUsuario);

            return lista.Select(p => new CourseProgressDTO
            {
                Id = p.Id,
                IdUsuario = p.IdUser,
                IdModulo = p.IdModule,
                DataConclusao = p.Date
            });
        }

        public async Task<DetailedProgressDTO> CalcularProgressoAsync(int idUsuario, int idCurso)
        {
            var modulos = await _moduloRepository.ListByCourseAsync(idCurso);
            int totalModulos = modulos.Count();

            if (totalModulos == 0)
            {
                return new DetailedProgressDTO
                {
                    IdCurso = idCurso,
                    TotalModulos = 0,
                    ModulosConcluidos = 0,
                    Porcentagem = 0
                };
            }

            
            var progresso = await _progressoRepository.ListByUserAsync(idUsuario);

            int concluidos = progresso
                .Count(p => modulos.Any(m => m.Id == p.IdModule));

            
            int porcentagem = (int)((double)concluidos / totalModulos * 100);

            return new DetailedProgressDTO
            {
                IdCurso = idCurso,
                TotalModulos = totalModulos,
                ModulosConcluidos = concluidos,
                Porcentagem = porcentagem
            };
        }

    }
}
