namespace TreinamentosCorp.API.Domain.Entities
{
    public class UserReport
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; } = string.Empty;
        public int PercentageProgress { get; set; }
        public int FinalNote { get; set; }
        public bool CertificateIssued { get; set; }
    }

    public class RelatorioCurso
    {
        public int IdCourse { get; set; }
        public string NameCourse { get; set; } = string.Empty;
        public int TotalUsers { get; set; }
        public int Completed { get; set; }
        public List<UserReport> User { get; set; } = new();
    }
}
