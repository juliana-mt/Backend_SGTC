namespace TreinamentosCorp.API.Domain.Entities
{
    public class Presence
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdCourse { get; private set; }
        public DateTime Date { get; private set; }
        public bool Present { get; private set; }

        public Presence(int idUser, int idCourse, DateTime date, bool present)
        {
            IdUser = idUser;
            IdCourse = idCourse;
            Date = date;
            Present = present;
        }

        public void UpdatePresence(bool present)
        {
            Present = present;
        }
    }
}
