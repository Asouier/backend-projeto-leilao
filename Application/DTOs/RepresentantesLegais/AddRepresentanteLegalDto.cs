namespace Api.DTOs.RepresentantesLegais
{
    public class AddRepresentanteLegalDto
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string DocumentoIdentificacao { get; set; }
        public required int ContatoId { get; set; }
    }
}
