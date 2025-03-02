namespace Application.DTOs.TipoImoveis
{
    public class UpdateTipoImovelDto
    {
        public required int Id { get; set; }
        public required string Descricao { get; set; }
    }
}
