namespace Application.DTOs.Veiculos
{
    public class NovoLanceVeiculoDto
    {
        public required string IdUsuarioArrematante { get; set; }
        public required decimal ValorDoLance { get; set; }
        public required int IdVeiculo { get; set; }
    }
}
