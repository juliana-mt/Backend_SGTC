using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _repo;

        public AvaliacaoService(IAvaliacaoRepository repo)
        {
            _repo = repo;
        }

        public async Task<AvaliacaoDTO> CreateAsync(CreateAvaliacaoDto dto)
        {
            var perguntas = dto.Perguntas
                .Select(p => new Pergunta(p.Texto, p.Opcoes, p.RespostaCorreta))
                .ToList();

            var avaliacao = new Avaliacao(dto.IdUsuario, dto.IdCurso, perguntas);
            await _repo.CreateAsync(avaliacao);

            return new AvaliacaoDTO
            {
                Id = avaliacao.Id,
                IdUsuario = avaliacao.IdUsuario,
                IdCurso = avaliacao.IdCurso,
                Perguntas = avaliacao.Perguntas
                            .Select(p => new PerguntaDTO { Id = p.Id, Texto = p.Texto, Opcoes = p.Opcoes })
                            .ToList()
            };
        }

        public async Task<AvaliacaoDTO?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new AvaliacaoDTO
            {
                Id = a.Id,
                IdUsuario = a.IdUsuario,
                IdCurso = a.IdCurso,
                Perguntas = a.Perguntas
                            .Select(p => new PerguntaDTO { Id = p.Id, Texto = p.Texto, Opcoes = p.Opcoes })
                            .ToList()
            };
        }

        public async Task<ResultadoAvaliacaoDto?> SubmitAsync(int avaliacaoId, SubmeterAvaliacaoDto dto)
        {
            return await _repo.SubmitAsync(avaliacaoId, dto);
        }

        public async Task<IEnumerable<ResultadoAvaliacaoDto>> GetResultadosByUsuarioAsync(int usuarioId)
        {
            return await _repo.GetResultadosByUsuarioAsync(usuarioId);
        }
    }

}