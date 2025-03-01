namespace Api.DTOs.Veiculos
{
    public class UpdateVeiculoDto
    {
        public int Id { get; set; }
        public int? LeilaoId { get; set; }
        public int? TipoVeiculoId { get; set; }
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public string? Cor { get; set; }
        public decimal? ValorMinimo { get; set; }
        public int? StatusPropriedadeId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string? MotivoRecolhimento { get; set; }
        public int? ClienteArrematanteId { get; set; }
    }
}
