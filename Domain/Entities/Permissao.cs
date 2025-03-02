namespace Domain.Entities
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public Permissao() { }

        public static Permissao Create(string descricao)
        {
            return new Permissao
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