namespace TreinamentosCorp.API.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty; // Ex: "Gestor", "Funcionario"
        public bool Ativo { get; set; }
    }
}
