namespace TreinamentosCorp.API.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cargo { get; private set; }
        public bool Ativo { get; private set; }
        public string SenhaHash { get; private set; }

        public Usuario(string nome, string email, string cargo, string senhaHash)
        {
            Nome = nome;
            Email = email;
            Cargo = cargo;
            SenhaHash = senhaHash;
            Ativo = true;
        }

        public void Atualizar(string nome, string email, string cargo)
        {
            Nome = nome;
            Email = email;
            Cargo = cargo;
        }

        public void DefinirSenha(string senhaHash)
        {
            SenhaHash = senhaHash;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }

}
