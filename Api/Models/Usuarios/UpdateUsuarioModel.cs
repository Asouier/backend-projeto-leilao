namespace Api.Models.Usuarios
{
    public class UpdateUsuarioModel
    {
        public string? NomeCompleto { get; set; }
        public required string Cpf { get; set; }
        public string? Rg { get; set; }
        public string? CargoFuncao { get; set; }
        public string? EntidadeResponsavel { get; set; }
        public int? CredencialId { get; set; }
        public int? ContatoId { get; set; }
        public int? PermissaoId { get; set; }
        public int? UsuarioConcessaoId { get; set; }
        public string? RegiaoResponsavel { get; set; }
        public string? CategoriaResponsavel { get; set; }
    }
}