namespace Api.Models.RepresentantesLegais
{
    public class UpdateRepresentanteLegalModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? DocumentoIdentificacao { get; set; }
        public int? ContatoId { get; set; }
    }
}
