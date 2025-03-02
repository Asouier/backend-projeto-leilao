namespace Application.Models.Imoveis
{
    public class UpdateImovelDto
    {
        public int Id { get; set; }
        public int? TipoImovelId { get; set; }
        public int? LeilaoId { get; set; }
        public int? EnderecoId { get; set; }
        public decimal? AreaTotal { get; set; }
        public int? QuantidadeComodos { get; set; }
        public decimal? ValorMinimo { get; set; }
        public int? StatusPropriedadeId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string? MotivoRecolhimento { get; set; }
        public int? ClienteArrematanteId { get; set; }
    }
}
