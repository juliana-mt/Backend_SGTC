using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.Application.DTOs.Requests
{
    public class CreateMaterialDTO
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
    }
}
