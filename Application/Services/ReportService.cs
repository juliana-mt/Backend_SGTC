using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly ICourseRepository _cursoRepository;
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IAssessmentRepository _avaliacaoRepository;
        private readonly IUserRepository _usuarioRepository;

        public ReportService(
            ICourseRepository cursoRepository,
            IProgressoCursoRepository progressoRepository,
            IAssessmentRepository avaliacaoRepository,
            IUserRepository usuarioRepository)
        {
            _cursoRepository = cursoRepository;
            _progressoRepository = progressoRepository;
            _avaliacaoRepository = avaliacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UserReportDTO>> GenerateByUserAsync(int usuarioId)
        {
            var progresso = await _progressoRepository.ListByUserAsync(usuarioId);
            var lista = new List<UserReportDTO>();

            foreach (var p in progresso)
            {
                var curso = await _cursoRepository.GetByIdAsync(p.IdModule);
                if (curso == null) continue; // evita desreferência nula

                var nota = await _avaliacaoRepository.GetFinalNoteAsync(usuarioId, curso.Id);

                var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);

                lista.Add(new UserReportDTO
                {
                    IdUsuario = usuarioId,
                    NomeUsuario = usuario?.Name ?? "Usuário",
                    Curso = curso.Name,
                    Nota = nota ?? 0,
                    Concluido = true,
                    DataConclusao = p.Date
                });
            }

            return lista;
        }


        public async Task<IEnumerable<CourseReportDTO>> GenerateByCourseAsync(int cursoId)
        {
            var curso = await _cursoRepository.GetByIdAsync(cursoId);
            if (curso == null) return Enumerable.Empty<CourseReportDTO>();

            var progresso = await _progressoRepository.ListByCourseAsync(cursoId);
            var lista = new List<CourseReportDTO>();

            var totalAlunos = progresso.Select(p => p.IdUser).Distinct().Count();
            var concluintes = progresso.GroupBy(p => p.IdUser)
                           .Count(g => g.All(m => m.Date > DateTime.MinValue));


            var notas = new List<double>();
            foreach (var usuarioId in progresso.Select(p => p.IdUser).Distinct())
            {
                var nota = await _avaliacaoRepository.GetFinalNoteAsync(usuarioId, cursoId);
                if (nota.HasValue) notas.Add(nota.Value);
            }

            lista.Add(new CourseReportDTO
            {
                IdCurso = cursoId,
                NomeCurso = curso.Name,
                TotalAlunos = totalAlunos,
                Concluintes = concluintes,
                NotaMedia = notas.Count > 0 ? notas.Average() : 0
            });

            return lista;
        }

    }
}
