namespace Backend.Domain.Entities
{
    public class StatusLeilao
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;

        private StatusLeilao() { }

        public static StatusLeilao Create(string descricao)
        {
            return new StatusLeilao
            {
                Descricao = descricao
            };
        }

        public void Update(string descricao)
        {
            Descricao = descricao;
        }
    }
}