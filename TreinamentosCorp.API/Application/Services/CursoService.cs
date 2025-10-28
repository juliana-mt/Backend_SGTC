using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;
using TreinamentosCorp.API.Domain.Services;

namespace TreinamentosCorp.API.Application.Servicess
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public IEnumerable<Curso> ObterTodos() => _cursoRepository.ObterTodos();

        public Curso ObterPorId(int id) => _cursoRepository.ObterPorId(id);

        public void Criar(Curso curso) => _cursoRepository.Criar(curso);

        public void Atualizar(Curso curso) => _cursoRepository.Atualizar(curso);

        public void Deletar(int id) => _cursoRepository.Deletar(id);
    }
}
