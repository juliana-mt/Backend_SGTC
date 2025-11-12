using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.Application.Services
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _repository;

        public ModuloService(IModuloRepository repository)
        {
            _repository = repository;
        }

        public async Task<ModuloDto> CriarAsync(CreateModuloDto dto, string caminhoArquivo)
        {
            var modulo = new Modulo(dto.IdCurso, dto.Titulo, dto.Tipo, caminhoArquivo);

            await _repository.CriarAsync(modulo);

            return new ModuloDto
            {
                Id = modulo.Id,
                IdCurso = modulo.IdCurso,
                Titulo = modulo.Titulo,
                Tipo = modulo.Tipo,
                CaminhoArquivo = modulo.CaminhoArquivo
            };
        }

        public async Task<IEnumerable<ModuloDto>> ListarPorCursoAsync(int idCurso)
        {
            var lista = await _repository.ListarPorCursoAsync(idCurso);

            return lista.Select(m => new ModuloDto
            {
                Id = m.Id,
                IdCurso = m.IdCurso,
                Titulo = m.Titulo,
                Tipo = m.Tipo,
                CaminhoArquivo = m.CaminhoArquivo
            });
        }

        public async Task<ModuloDto?> GetByIdAsync(int id)
        {
            var m = await _repository.ObterPorIdAsync(id);
            if (m == null) return null;

            return new ModuloDto
            {
                Id = m.Id,
                IdCurso = m.IdCurso,
                Titulo = m.Titulo,
                Tipo = m.Tipo,
                CaminhoArquivo = m.CaminhoArquivo
            };
        }
    }
}
