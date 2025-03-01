namespace Api.Models.Enderecos
{
    public class AddEnderecoModel
    {
        public required string Cep { get; set; }
        public required string Descricao { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Pais { get; set; }
        public required string Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
