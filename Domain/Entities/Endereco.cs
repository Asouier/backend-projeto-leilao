namespace Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }

        public Endereco() { }

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
