using TreinamentosCorp.API.Domain.Entities;
using TreinamentosCorp.API.Domain.Repositories;

namespace TreinamentosCorp.API.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly List<Curso> _cursos = new();

        public IEnumerable<Curso> ObterTodos() => _cursos;

        public Curso ObterPorId(int id) => _cursos.FirstOrDefault(c => c.Id == id);

        public void Criar(Curso curso)
        {
            curso.GetType().GetProperty("Id")?.SetValue(curso, _cursos.Count + 1);
            _cursos.Add(curso);
        }

        public void Atualizar(Curso curso)
        {
            var existente = ObterPorId(curso.Id);
            if (existente != null)
            {
                _cursos.Remove(existente);
                _cursos.Add(curso);
            }
        }

        public void Deletar(int id)
        {
            var curso = ObterPorId(id);
            if (curso != null) _cursos.Remove(curso);
        }
    }
}
