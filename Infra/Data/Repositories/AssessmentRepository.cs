using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly DataContext _context;

        public AssessmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Assessment> CreateAsync(Assessment avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Assessment?> GetByIdAsync(int id)
        {
            return await _context.Avaliacoes
                                 .Include(a => a.Questions)
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AssessmentResultsDTO?> SubmitAsync(int avaliacaoId, SubmitAssessmentDTO dto)
        {
            var avaliacao = await GetByIdAsync(avaliacaoId);
            if (avaliacao == null) return null;

            int total = avaliacao.Questions.Count;
            int acertos = 0;

            foreach (var resposta in dto.Respostas)
            {
                var pergunta = avaliacao.Questions.FirstOrDefault(p => p.Id == resposta.IdPergunta);
                if (pergunta != null && pergunta.CorrectAnswer == resposta.OpcaoSelecionada)
                    acertos++;
            }

            int nota = total > 0 ? (int)((acertos / (double)total) * 100) : 0;

            return new AssessmentResultsDTO
            {
                IdAvaliacao = avaliacaoId,
                IdUsuario = dto.IdUsuario,
                Nota = nota
            };
        }

        public Task<IEnumerable<AssessmentResultsDTO>> GetResultByUserAsync(int usuarioId)
        {
            return Task.FromResult<IEnumerable<AssessmentResultsDTO>>(new List<AssessmentResultsDTO>());
        }

        // Usar para certificado automático
        public async Task<int?> GetFinalNoteAsync(int usuarioId, int cursoId)
        {
            var avaliacao = await _context.Avaliacoes
                .Where(a => a.IdUser == usuarioId && a.IdCourse == cursoId)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            if (avaliacao == null)
                return null;

            return avaliacao.Note;
        }
    }
}
