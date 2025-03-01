namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int CredencialId { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public string EntidadeResponsavel { get; set; } = string.Empty;
        public string NomeCompleto { get; set; } = string.Empty;
        public int ContatoId { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string CargoFuncao { get; set; } = string.Empty;
        public int PermissaoId { get; set; }
        public int? UsuarioConcessaoId { get; set; }
        public string? RegiaoResponsavel { get; set; }
        public string? CategoriaResponsavel { get; set; }

        public Credencial Credencial { get; set; } = null!;
        public Contato Contato { get; set; } = null!;
        public Permissao Permissao { get; set; } = null!;
        public Usuario? UsuarioConcessao { get; set; }

        public Usuario() { }

        public static Usuario Create(int credencialId, string entidadeResponsavel, string nomeCompleto, int contatoId, string cpf, string rg, string cargoFuncao, int permissaoId, int? usuarioConcessaoId = null, string? regiaoResponsavel = null, string? categoriaResponsavel = null)
        {
            return new Usuario
            {
                CredencialId = credencialId,
                DataHoraRegistro = DateTime.UtcNow,
                EntidadeResponsavel = entidadeResponsavel,
                NomeCompleto = nomeCompleto,
                ContatoId = contatoId,
                Cpf = cpf,
                Rg = rg,
                CargoFuncao = cargoFuncao,
                PermissaoId = permissaoId,
                UsuarioConcessaoId = usuarioConcessaoId,
                RegiaoResponsavel = regiaoResponsavel,
                CategoriaResponsavel = categoriaResponsavel
            };
        }

        public void Update(string entidadeResponsavel, string nomeCompleto, int contatoId, string cpf, string rg, string cargoFuncao, int permissaoId, int? usuarioConcessaoId = null, string? regiaoResponsavel = null, string? categoriaResponsavel = null)
        {
            EntidadeResponsavel = entidadeResponsavel;
            NomeCompleto = nomeCompleto;
            ContatoId = contatoId;
            Cpf = cpf;
            Rg = rg;
            CargoFuncao = cargoFuncao;
            PermissaoId = permissaoId;
            UsuarioConcessaoId = usuarioConcessaoId;
            RegiaoResponsavel = regiaoResponsavel;
            CategoriaResponsavel = categoriaResponsavel;
        }
    }
}
