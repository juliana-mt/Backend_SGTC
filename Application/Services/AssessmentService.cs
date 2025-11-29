using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _repo;

        public AssessmentService(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<AssessmentDTO> CreateAsync(CreateAssessmentDTO dto)
        {
            var perguntas = dto.Perguntas
                .Select(p => new Question(p.Texto, p.Opcoes, p.RespostaCorreta))
                .ToList();

            var avaliacao = new Assessment(dto.IdUsuario, dto.IdCurso, perguntas);
            await _repo.CreateAsync(avaliacao);

            return new AssessmentDTO
            {
                Id = avaliacao.Id,
                IdUsuario = avaliacao.IdUser,
                IdCurso = avaliacao.IdCourse,
                Perguntas = avaliacao.Questions
                            .Select(p => new PerguntaDTO { Id = p.Id, Texto = p.Text, Opcoes = p.Options })
                            .ToList()
            };
        }

        public async Task<AssessmentDTO?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new AssessmentDTO
            {
                Id = a.Id,
                IdUsuario = a.IdUser,
                IdCurso = a.IdCourse,
                Perguntas = a.Questions
                            .Select(p => new PerguntaDTO { Id = p.Id, Texto = p.Text, Opcoes = p.Options })
                            .ToList()
            };
        }

        public async Task<AssessmentResultsDTO?> SubmitAsync(int avaliacaoId, SubmitAssessmentDTO dto)
        {
            return await _repo.SubmitAsync(avaliacaoId, dto);
        }

        public async Task<IEnumerable<AssessmentResultsDTO>> GetResultadosByUsuarioAsync(int usuarioId)
        {
            return await _repo.GetResultByUserAsync(usuarioId);
        }
    }

}