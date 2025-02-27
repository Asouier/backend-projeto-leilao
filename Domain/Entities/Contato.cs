namespace Domain.Entities
{
    public class Contato
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;

        private Contato() { }

        public static Contato Create(string email, string telefone)
        {
            return new Contato
            {
                Email = email,
                Telefone = telefone
            };
        }

        public void Update(string email, string telefone)
        {
            Email = email;
            Telefone = telefone;
        }
    }
}
