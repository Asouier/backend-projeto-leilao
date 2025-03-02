namespace Domain.Entities
{
    public class RepresentanteLegal
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string DocumentoIdentificacao { get; set; } = string.Empty;
        public int? ContatoId { get; set; }

        public Contato? Contato { get; set; }

        private RepresentanteLegal() { }

        public static RepresentanteLegal Create(string nome, string cpf, string documentoIdentificacao, int? contatoId = null)
        {
            return new RepresentanteLegal
            {
                Nome = nome,
                Cpf = cpf,
                DocumentoIdentificacao = documentoIdentificacao,
                ContatoId = contatoId
            };
        }

        public void Update(string nome, string cpf, string documentoIdentificacao, int? contatoId = null)
        {
            Nome = nome;
            Cpf = cpf;
            DocumentoIdentificacao = documentoIdentificacao;
            ContatoId = contatoId;
        }
    }
}
