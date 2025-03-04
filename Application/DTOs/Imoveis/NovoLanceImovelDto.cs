namespace Application.DTOs.Imoveis
{
    public class NovoLanceImovelDto
    {
        public required int ClienteArrematanteId { get; set; }
        public required decimal ValorMinimo { get; set; }
        public required int IdImovel { get; set; }
    }
}

