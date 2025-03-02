namespace Domain.Entities
{
    public class StatusPropriedade
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        private StatusPropriedade() { }

        public static StatusPropriedade Create(string descricao)
        {
            return new StatusPropriedade
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