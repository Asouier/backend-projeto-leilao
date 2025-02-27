namespace Domain.Entities
{
    public class Permissao
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;

        private Permissao() { }

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