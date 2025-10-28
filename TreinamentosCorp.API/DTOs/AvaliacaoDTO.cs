namespace TreinamentosCorp.API.DTOs
{
    public class AvaliacaoDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}
