namespace Application.DTOs.Veiculos
{
    public class AddVeiculoDto
    {
        public required int LeilaoId { get; set; }
        public required int TipoVeiculoId { get; set; }
        public required string Placa { get; set; }
        public required string Chassi { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public required int AnoFabricacao { get; set; }
        public required string Cor { get; set; }
        public required decimal ValorMinimo { get; set; }
        public int StatusPropriedadeId { get; set; } = 1;
        public required int UsuarioCadastroId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public required string MotivoRecolhimento { get; set; }
    }
}
