using Microsoft.EntityFrameworkCore;
using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Infra.Data.Context;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly DataContext _context;

        public AvaliacaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Avaliacao> CreateAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao?> GetByIdAsync(int id)
        {
            return await _context.Avaliacoes
                                 .Include(a => a.Perguntas)
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ResultadoAvaliacaoDto?> SubmitAsync(int avaliacaoId, SubmeterAvaliacaoDto dto)
        {
            var avaliacao = await GetByIdAsync(avaliacaoId);
            if (avaliacao == null) return null;

            int total = avaliacao.Perguntas.Count;
            int acertos = 0;

            foreach (var resposta in dto.Respostas)
            {
                var pergunta = avaliacao.Perguntas.FirstOrDefault(p => p.Id == resposta.PerguntaId);
                if (pergunta != null && pergunta.RespostaCorreta == resposta.OpcaoSelecionada)
                    acertos++;
            }

            int nota = total > 0 ? (int)((acertos / (double)total) * 100) : 0;

            return new ResultadoAvaliacaoDto
            {
                IdAvaliacao = avaliacaoId,
                IdUsuario = dto.IdUsuario,
                Nota = nota
            };
        }

        public Task<IEnumerable<ResultadoAvaliacaoDto>> GetResultadosByUsuarioAsync(int usuarioId)
        {
            return Task.FromResult<IEnumerable<ResultadoAvaliacaoDto>>(new List<ResultadoAvaliacaoDto>());
        }

        // Usar para certificado automático
        public async Task<int?> ObterNotaFinalAsync(int usuarioId, int cursoId)
        {
            var avaliacao = await _context.Avaliacoes
                .Where(a => a.IdUsuario == usuarioId && a.IdCurso == cursoId)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            if (avaliacao == null)
                return null;

            return avaliacao.Nota;
        }
    }
}
