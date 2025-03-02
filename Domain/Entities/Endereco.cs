namespace Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public required string Cep { get; set; }
        public required string Descricao { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Pais { get; set; }
        public required string Numero { get; set; }
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
