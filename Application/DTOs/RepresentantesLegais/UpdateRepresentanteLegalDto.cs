namespace Api.DTOs.RepresentantesLegais
{
    public class UpdateRepresentanteLegalDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? DocumentoIdentificacao { get; set; }
        public int? ContatoId { get; set; }
    }
}
