using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class CourseProgressDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
