using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreateModuleDTO
    {
        public int IdCurso { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = "video"; // video | pdf | outro
    }
}
