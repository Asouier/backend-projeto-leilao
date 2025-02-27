namespace Domain.Entities
{
    public class Endereco
    {
        public int Id { get; private set; }
        public string Cep { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;
        public string Pais { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string? Complemento { get; private set; }

        private Endereco() { }

        public static Endereco Create(string cep, string descricao, string cidade, string estado, string pais, string numero, string? complemento = null)
        {
            return new Endereco
            {
                Cep = cep,
                Descricao = descricao,
                Cidade = cidade,
                Estado = estado,
                Pais = pais,
                Numero = numero,
                Complemento = complemento
            };
        }

        public void Update(string cep, string descricao, string cidade, string estado, string pais, string numero, string? complemento = null)
        {
            Cep = cep;
            Descricao = descricao;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
