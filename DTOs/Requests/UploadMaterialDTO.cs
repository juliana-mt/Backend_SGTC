using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class UploadMaterialDto
    {
        public int IdCurso { get; set; }
        public IFormFile Arquivo { get; set; }
    }
}
