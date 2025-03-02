namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int? CredencialId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? NomeCompleto { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public int? RepresentanteLegalId { get; set; }
        public int EnderecoId { get; set; }
        public int ContatoId { get; set; }
        public string? Certidao { get; set; }

        public Credencial? Credencial { get; set; }
        public RepresentanteLegal? RepresentanteLegal { get; set; }
        public Endereco Endereco { get; set; } = null!;
        public Contato Contato { get; set; } = null!;

        public Cliente() { }

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
