namespace Application.DTOs.Veiculos
{
    public class NovoLanceVeiculoDto
    {
        public required int ClienteArrematanteId { get; set; }
        public required decimal ValorMinimo { get; set; }
        public required int IdVeiculo { get; set; }
    }
}
