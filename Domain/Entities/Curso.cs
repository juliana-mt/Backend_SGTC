namespace TreinamentosCorp.API.Domain.Entities
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public bool Ativo { get; private set; }
        public int NotaMinima { get; private set; } = 60;
        public int CargaHoraria { get; private set; }


        public Curso(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
        }

        public void Atualizar(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
