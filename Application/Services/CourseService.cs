using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _cursoRepository;

        public CourseService(ICourseRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Course> CreateAsync(CreateCourseDTO dto)
        {
            var curso = new Course(dto.Nome, dto.Descricao);
            await _cursoRepository.CreateAsync(curso);
            return curso;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _cursoRepository.GetByIdAsync(id);
        }
    }
}
