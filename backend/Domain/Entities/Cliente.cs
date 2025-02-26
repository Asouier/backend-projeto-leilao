namespace Backend.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public int? CredencialId { get; private set; }
        public DateTime DataHoraCadastro { get; private set; }
        public string? Rg { get; private set; }
        public string? OrgaoEmissor { get; private set; }
        public string? Cpf { get; private set; }
        public string? Cnpj { get; private set; }
        public string? NomeCompleto { get; private set; }
        public string? NomeFantasia { get; private set; }
        public string? RazaoSocial { get; private set; }
        public int? RepresentanteLegalId { get; private set; }
        public int EnderecoId { get; private set; }
        public int ContatoId { get; private set; }
        public string? Certidao { get; private set; }

        public Credencial? Credencial { get; private set; }
        public RepresentanteLegal? RepresentanteLegal { get; private set; }
        public Endereco Endereco { get; private set; } = null!;
        public Contato Contato { get; private set; } = null!;

        private Cliente() { }

        public static Cliente Create(int? credencialId, string? rg, string? orgaoEmissor, string? cpf, string? cnpj, string? nomeCompleto, string? nomeFantasia, string? razaoSocial, int? representanteLegalId, int enderecoId, int contatoId, string? certidao = null)
        {
            return new Cliente
            {
                CredencialId = credencialId,
                DataHoraCadastro = DateTime.UtcNow,
                Rg = rg,
                OrgaoEmissor = orgaoEmissor,
                Cpf = cpf,
                Cnpj = cnpj,
                NomeCompleto = nomeCompleto,
                NomeFantasia = nomeFantasia,
                RazaoSocial = razaoSocial,
                RepresentanteLegalId = representanteLegalId,
                EnderecoId = enderecoId,
                ContatoId = contatoId,
                Certidao = certidao
            };
        }

        public void Update(int? credencialId, string? rg, string? orgaoEmissor, string? cpf, string? cnpj, string? nomeCompleto, string? nomeFantasia, string? razaoSocial, int? representanteLegalId, int enderecoId, int contatoId, string? certidao = null)
        {
            CredencialId = credencialId;
            Rg = rg;
            OrgaoEmissor = orgaoEmissor;
            Cpf = cpf;
            Cnpj = cnpj;
            NomeCompleto = nomeCompleto;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            RepresentanteLegalId = representanteLegalId;
            EnderecoId = enderecoId;
            ContatoId = contatoId;
            Certidao = certidao;
        }
    }
}
