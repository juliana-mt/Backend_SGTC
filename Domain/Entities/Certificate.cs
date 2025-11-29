using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TreinamentosCorp.API.Domain.Entities
{
    public class Certificate
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdCourse { get; private set; }
        public DateTime Date { get; private set; }
        public string ValidationCode { get; private set; }

        public Certificate(int idUser, int idCourse, string validationCode)
        {
            IdUser = idUser;
            IdCourse = idCourse;
            ValidationCode = validationCode;
            Date = DateTime.UtcNow;
        }
    }
}
