namespace Application.DTOs.Veiculos
{
    public class VeiculoDto
    {
        public int Id { get; set; }
        public int LeilaoId { get; set; }
        public int TipoVeiculoId { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; } = string.Empty;
        public decimal ValorMinimo { get; set; }
        public int StatusPropriedadeId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioCadastroId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string MotivoRecolhimento { get; set; } = string.Empty;
        public int? ClienteArrematanteId { get; set; }
    }
}
