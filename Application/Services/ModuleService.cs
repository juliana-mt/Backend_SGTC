using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ModuleDTO> CriarAsync(CreateModuleDTO dto, string caminhoArquivo)
        {
            var modulo = new Module(dto.IdCurso, dto.Titulo, dto.Tipo, caminhoArquivo);

            await _repository.CreateAsync(modulo);

            return new ModuleDTO
            {
                Id = modulo.Id,
                IdCurso = modulo.IdCourse,
                Titulo = modulo.Title,
                Tipo = modulo.Type,
                CaminhoArquivo = modulo.PathFile
            };
        }

        public async Task<IEnumerable<ModuleDTO>> ListarPorCursoAsync(int idCurso)
        {
            var lista = await _repository.ListByCourseAsync(idCurso);

            return lista.Select(m => new ModuleDTO
            {
                Id = m.Id,
                IdCurso = m.IdCourse,
                Titulo = m.Title,
                Tipo = m.Type,
                CaminhoArquivo = m.PathFile
            });
        }

        public async Task<ModuleDTO?> GetByIdAsync(int id)
        {
            var m = await _repository.GetByIdAsync(id);
            if (m == null) return null;

            return new ModuleDTO
            {
                Id = m.Id,
                IdCurso = m.IdCourse,
                Titulo = m.Title,
                Tipo = m.Type,
                CaminhoArquivo = m.PathFile
            };
        }
    }
}
