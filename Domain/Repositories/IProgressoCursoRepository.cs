using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IProgressoCursoRepository
    {
        Task RegistrarAsync(ProgressoCurso progresso);
        Task<bool> ExisteAsync(int idUsuario, int idModulo);
        Task<IEnumerable<ProgressoCurso>> ListarPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<ProgressoCurso>> ListarPorCursoAsync(int idCurso);


    }
}
