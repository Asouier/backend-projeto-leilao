namespace Api.Models.Imoveis
{
    public class AddImovelModel
    {
        public required int TipoImovelId { get; set; }
        public required int LeilaoId { get; set; }
        public required int EnderecoId { get; set; }
        public required decimal AreaTotal { get; set; }
        public int? QuantidadeComodos { get; set; }
        public required decimal ValorMinimo { get; set; }
        public int? StatusPropriedadeId { get; set; } = 1;
        public required int UsuarioCadastroId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public required string MotivoRecolhimento { get; set; }
    }
}
