namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public int CredencialId { get; private set; }
        public DateTime DataHoraRegistro { get; private set; }
        public string EntidadeResponsavel { get; private set; } = string.Empty;
        public string NomeCompleto { get; private set; } = string.Empty;
        public int ContatoId { get; private set; }
        public string Cpf { get; private set; } = string.Empty;
        public string Rg { get; private set; } = string.Empty;
        public string CargoFuncao { get; private set; } = string.Empty;
        public int PermissaoId { get; private set; }
        public int? UsuarioConcessaoId { get; private set; }
        public string? RegiaoResponsavel { get; private set; }
        public string? CategoriaResponsavel { get; private set; }

        public Credencial Credencial { get; private set; } = null!;
        public Contato Contato { get; private set; } = null!;
        public Permissao Permissao { get; private set; } = null!;
        public Usuario? UsuarioConcessao { get; private set; }

        private Usuario() { }

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
