using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> ObterTodos();
        Curso ObterPorId(int id);
        void Criar(Curso curso);
        void Atualizar(Curso curso);
        void Deletar(int id);
    }
}
