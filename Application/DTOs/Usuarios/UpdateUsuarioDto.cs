namespace Api.DTOs.Usuarios
{
    public class UpdateUsuarioDto
    {
        public string? NomeCompleto { get; set; }
        public string? Rg { get; set; }
        public string? CargoFuncao { get; set; }
        public string? EntidadeResponsavel { get; set; }
        public int? PermissaoId { get; set; }
        public int? UsuarioConcessaoId { get; set; }
        public string? RegiaoResponsavel { get; set; }
        public string? CategoriaResponsavel { get; set; }
    }
}