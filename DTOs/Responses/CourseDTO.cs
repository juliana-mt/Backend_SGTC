using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
