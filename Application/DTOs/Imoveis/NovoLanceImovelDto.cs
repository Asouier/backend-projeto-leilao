namespace Application.DTOs.Imoveis
{
    public class NovoLanceImovelDto
    {
        public required string IdUsuarioArrematante { get; set; }
        public required decimal ValorDoLance { get; set; }
        public required int IdImovel { get; set; }
    }
}

