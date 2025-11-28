using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class CertificadoDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoValidacao { get; set; } = string.Empty;

        public string NomeUsuario { get; set; } = string.Empty;
        public string NomeCurso { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
    }
}