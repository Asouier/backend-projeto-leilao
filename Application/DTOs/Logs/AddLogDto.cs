namespace Application.DTOs.Logs
{
    public class AddLogDto
    {
        public int? UsuarioId { get; set; }
        public int? ClienteId { get; set; }
        public int? LeilaoId { get; set; }
        public required string Entidade { get; set; }
        public required int EntidadeId { get; set; }
        public required string Acao { get; set; }
    }
}
