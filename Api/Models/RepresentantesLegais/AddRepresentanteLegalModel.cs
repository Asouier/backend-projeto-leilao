namespace Api.Models.RepresentantesLegais
{
    public class AddRepresentanteLegalModel
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string DocumentoIdentificacao { get; set; }
        public required int ContatoId { get; set; }
    }
}
