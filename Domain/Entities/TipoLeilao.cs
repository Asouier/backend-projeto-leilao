namespace Domain.Entities
{
    public class TipoLeilao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        private TipoLeilao() { }

        public static TipoLeilao Create(string descricao)
        {
            return new TipoLeilao
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