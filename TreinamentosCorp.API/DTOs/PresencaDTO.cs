namespace TreinamentosCorp.API.DTOs
{
    public class PresencaDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataPresenca { get; set; }
        public bool Presente { get; set; }
    }
}
