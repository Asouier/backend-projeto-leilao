namespace Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        public Contato() { }

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
