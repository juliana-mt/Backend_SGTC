using TreinamentosCorp.API.Domain.Entities;

namespace TreinamentosCorp.API.Domain.Repositories
{
    public interface IProgressoCursoRepository
    {
        Task RegisterAsync(CourseProgress progress);
        Task<bool> ExistsAsync(int idUser, int idModule);
        Task<IEnumerable<CourseProgress>> ListByUserAsync(int idUser);
        Task<IEnumerable<CourseProgress>> ListByCourseAsync(int idCourse);


    }
}
