namespace Api.Models.Contatos
{
    public class UpdateContatoDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
