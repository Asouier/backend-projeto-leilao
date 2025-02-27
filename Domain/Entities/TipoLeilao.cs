namespace Domain.Entities
{
    public class TipoLeilao
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;

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