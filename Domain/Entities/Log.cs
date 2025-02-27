namespace Domain.Entities
{
    public class Log
    {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public int? ClienteId { get; private set; }
        public int? LeilaoId { get; private set; }
        public string Entidade { get; private set; } = string.Empty;
        public int EntidadeId { get; private set; }
        public DateTime DataHora { get; private set; }
        public string Acao { get; private set; } = string.Empty;

        public Usuario Usuario { get; private set; } = null!;
        public Cliente? Cliente { get; private set; }
        public Leilao? Leilao { get; private set; }

        private Log() { }

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
