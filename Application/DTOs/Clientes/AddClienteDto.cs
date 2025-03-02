namespace Application.DTOs.Clientes
{
    public class AddClienteDto
    {
        public int? CredencialId { get; set; }
        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? NomeCompleto { get; set; }
        public string? NomeFantasia { get; set; }
        public required string NomeUsuario { get; set; }
        public required string Senha { get; set; }
        public string? RazaoSocial { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Certidao { get; set; }
    }
}

