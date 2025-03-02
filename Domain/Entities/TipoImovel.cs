namespace Domain.Entities
{
    public class TipoImovel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        private TipoImovel() { }

        public static TipoImovel Create(string descricao)
        {
            return new TipoImovel
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