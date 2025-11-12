using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Curso> CreateAsync(CreateCursoDto dto)
        {
            var curso = new Curso(dto.Nome, dto.Descricao);
            await _cursoRepository.CreateAsync(curso);
            return curso;
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            return await _cursoRepository.GetByIdAsync(id);
        }
    }
}
