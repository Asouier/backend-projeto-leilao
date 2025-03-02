namespace Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ClienteId { get; set; }
        public int? LeilaoId { get; set; }
        public string Entidade { get; set; } = string.Empty;
        public int EntidadeId { get; set; }
        public DateTime DataHora { get; set; }
        public string Acao { get; set; } = string.Empty;

        public Usuario Usuario { get; set; } = null!;
        public Cliente? Cliente { get; set; }
        public Leilao? Leilao { get; set; }

        public Log() { }

        public static Log Create(int usuarioId, int? clienteId, int? leilaoId, string entidade, int entidadeId, string acao)
        {
            return new Log
            {
                UsuarioId = usuarioId,
                ClienteId = clienteId,
                LeilaoId = leilaoId,
                Entidade = entidade,
                EntidadeId = entidadeId,
                DataHora = DateTime.UtcNow,
                Acao = acao
            };
        }
    }
}
