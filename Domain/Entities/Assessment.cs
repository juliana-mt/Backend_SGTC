namespace TreinamentosCorp.API.Domain.Entities
{
    public class Assessment
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdCourse { get; private set; }
        public int Note { get; private set; }
        public string Comment { get; private set; } = string.Empty;
        public List<Question> Questions { get; private set; } = new();

        private Assessment() { }

        public Assessment(int idUser, int idCourse, List<Question> questions)
        {
            IdUser = idUser;
            IdCourse = idCourse;
            Questions = questions;
        }

        public void DefineNote(int note) => Note = note;
        public void DefineComment(string comment) => Comment = comment;
    }
}
