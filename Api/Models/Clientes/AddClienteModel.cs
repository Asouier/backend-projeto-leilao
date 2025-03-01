namespace Api.Models.Clientes
{
    public class AddClienteModel
    {
        public int? CredencialId { get; set; }
        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? NomeCompleto { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public int? RepresentanteLegalId { get; set; }
        public required int EnderecoId { get; set; }
        public required int ContatoId { get; set; }
        public string? Certidao { get; set; }
    }
}
