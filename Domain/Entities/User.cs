namespace TreinamentosCorp.API.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Position { get; private set; }
        public bool Active { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string name, string email, string position, string passwordHash)
        {
            Name = name;
            Email = email;
            Position = position;
            PasswordHash = passwordHash;
            Active = true;
        }

        public void Update(string name, string email, string position)
        {
            Name = name;
            Email = email;
            Position = position;
        }

        public void DefinePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void Activate() => Active = true;
        public void Disable() => Active = false;
    }

}
