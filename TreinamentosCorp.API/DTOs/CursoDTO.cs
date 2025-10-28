namespace TreinamentosCorp.API.DTOs
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Instrutor { get; set; } = string.Empty;
    }
}
