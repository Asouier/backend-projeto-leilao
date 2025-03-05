namespace Application.DTOs.Credenciais
{
    public class ResponseLoginDto
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string? NomeCompleto { get; set; }
        public string? NomeFantasia { get; set; }
        public string? Cidade { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? CargoFuncao { get; set; }
        public int? PermissaoId { get; set; }
        public string? RegiaoResponsavel { get; set; }
        public string? CategoriaResponsavel { get; set; }
    }


}
