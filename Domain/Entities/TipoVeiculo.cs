namespace Domain.Entities
{
    public class TipoVeiculo
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        private TipoVeiculo() { }

        public static TipoVeiculo Create(string descricao)
        {
            return new TipoVeiculo
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