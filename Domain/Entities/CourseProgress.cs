namespace TreinamentosCorp.API.Domain.Entities
{
    public class CourseProgress
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdModule { get; private set; }
        public DateTime Date { get; private set; }
        public int IdCourse { get; private set; }

        public CourseProgress(int idUser, int idModule, int idCourse)
        {
            IdUser = idUser;
            IdCourse = idCourse;
            IdModule = idModule;
            Date = DateTime.Now;
        }
    }
}
