namespace Backend.Domain.Entities
{
    public class RepresentanteLegal
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string DocumentoIdentificacao { get; private set; } = string.Empty;
        public int? ContatoId { get; private set; }

        public Contato? Contato { get; private set; }

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
