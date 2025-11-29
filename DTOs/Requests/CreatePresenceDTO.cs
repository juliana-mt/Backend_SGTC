using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreatePresenceDTO
    {
        public int IdUsuario { get; set; }
        public int IdCurso{ get; set; }
        public DateTime DataPresenca { get; set; } = DateTime.UtcNow;
        public bool Presente { get; set; }
    }
}
