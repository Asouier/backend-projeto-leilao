namespace Application.DTOs.Veiculos
{
    public class NovoLanceDto
    {
        public required string IdUsuarioArrematante { get; set; }
        public required decimal ValorDoLance { get; set; }
        public required int IdVeiculo { get; set; }
    }
}
