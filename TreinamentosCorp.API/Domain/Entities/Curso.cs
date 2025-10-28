namespace TreinamentosCorp.API.Domain.Entities
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public string Instrutor { get; private set; }

        public Curso(string titulo, string descricao, DateTime dataInicio, DateTime dataFim, string instrutor)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Instrutor = instrutor;
        }

        public void Atualizar(string titulo, string descricao, DateTime dataInicio, DateTime dataFim, string instrutor)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Instrutor = instrutor;
        }
    }
}
namespace TreinamentosCorp.API.Domain
{
    public class Class
    {
    }
}
