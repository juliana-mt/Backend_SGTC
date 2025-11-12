using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IProgressoCursoRepository _progressoRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RelatorioService(
            ICursoRepository cursoRepository,
            IProgressoCursoRepository progressoRepository,
            IAvaliacaoRepository avaliacaoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _cursoRepository = cursoRepository;
            _progressoRepository = progressoRepository;
            _avaliacaoRepository = avaliacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<RelatorioUsuarioDTO>> GerarPorUsuarioAsync(int usuarioId)
        {
            var progresso = await _progressoRepository.ListarPorUsuarioAsync(usuarioId);
            var lista = new List<RelatorioUsuarioDTO>();

            foreach (var p in progresso)
            {
                var curso = await _cursoRepository.GetByIdAsync(p.IdModulo); 
                var nota = await _avaliacaoRepository.ObterNotaFinalAsync(usuarioId, curso.Id);
                lista.Add(new RelatorioUsuarioDTO
                {
                    IdUsuario = usuarioId,
                    NomeUsuario = (await _usuarioRepository.GetByIdAsync(usuarioId))?.Nome ?? "Usuário",
                    Curso = curso.Nome,
                    Nota = nota ?? 0,
                    Concluido = true,
                    DataConclusao = p.DataConclusao
                });
            }

            return lista;
        }

        public async Task<IEnumerable<RelatorioCursoDTO>> GerarPorCursoAsync(int cursoId)
        {
            var modulos = await _cursoRepository.GetByIdAsync(cursoId);
            var progresso = await _progressoRepository.ListarPorCursoAsync(cursoId); 
            var lista = new List<RelatorioCursoDTO>();

            var totalAlunos = progresso.Select(p => p.IdUsuario).Distinct().Count();
            var concluintes = progresso.GroupBy(p => p.IdUsuario)
                                       .Count(g => g.All(m => m.DataConclusao != null));

            var notas = new List<double>();
            foreach (var usuarioId in progresso.Select(p => p.IdUsuario).Distinct())
            {
                var nota = await _avaliacaoRepository.ObterNotaFinalAsync(usuarioId, cursoId);
                if (nota.HasValue) notas.Add(nota.Value);
            }

            lista.Add(new RelatorioCursoDTO
            {
                IdCurso = cursoId,
                NomeCurso = modulos.Nome,
                TotalAlunos = totalAlunos,
                Concluintes = concluintes,
                NotaMedia = notas.Count > 0 ? notas.Average() : 0
            });

            return lista;
        }
    }
}
