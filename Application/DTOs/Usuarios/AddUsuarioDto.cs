namespace Application.DTOs.Usuarios
{
    public class AddUsuarioDto
    {
        public required string NomeCompleto { get; set; }
        public required string Cpf { get; set; }
        public required string Rg { get; set; }
        public required string CargoFuncao { get; set; }
        public required string EntidadeResponsavel { get; set; }
        public required string Usuario { get; set; }
        public required string Senha { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required int PermissaoId { get; set; }
        public int? UsuarioConcessaoId { get; set; }
        public string? RegiaoResponsavel { get; set; }
        public string CategoriaResponsavel { get; set; } = "Todas";
    }
}