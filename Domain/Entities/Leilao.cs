namespace Domain.Entities
{
    public class Leilao
    {
        public int Id { get; private set; }
        public int TipoLeilaoId { get; private set; }
        public int StatusId { get; private set; }
        public int EnderecoId { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime DataHoraFim { get; private set; }
        public string UrlLeilao { get; private set; } = string.Empty;
        public int UsuarioCadastroId { get; private set; }
        public int? UsuarioAprovacaoId { get; private set; }
        public decimal TaxaAdministrativa { get; private set; }
        public decimal ValorArrecadado { get; private set; }
        public DateTime DataHoraRegistro { get; private set; }
        public DateTime DataHoraAtualizacao { get; private set; }

        public TipoLeilao TipoLeilao { get; private set; } = null!;
        public ICollection<Imovel>? Imoveis { get; set; }
        public ICollection<Veiculo>? Veiculos { get; set; }
        public StatusLeilao Status { get; private set; } = null!;
        public Endereco Endereco { get; private set; } = null!;
        public Usuario UsuarioCadastro { get; private set; } = null!;
        public Usuario? UsuarioAprovacao { get; private set; }

        private Leilao() { }

        public static Leilao Create(int tipoLeilaoId, int statusId, int enderecoId, DateTime dataHoraInicio, DateTime dataHoraFim, string urlLeilao, ICollection<Imovel>? imoveis, ICollection<Veiculo>? veiculos, int usuarioCadastroId, decimal taxaAdministrativa, int? usuarioAprovacaoId = null)
        {
            return new Leilao
            {
                TipoLeilaoId = tipoLeilaoId,
                StatusId = statusId,
                EnderecoId = enderecoId,
                DataHoraInicio = dataHoraInicio,
                DataHoraFim = dataHoraFim,
                UrlLeilao = urlLeilao,
                Imoveis = imoveis,
                Veiculos = veiculos,
                UsuarioCadastroId = usuarioCadastroId,
                UsuarioAprovacaoId = usuarioAprovacaoId,
                TaxaAdministrativa = taxaAdministrativa,
                ValorArrecadado = 0,
                DataHoraRegistro = DateTime.UtcNow,
                DataHoraAtualizacao = DateTime.UtcNow
            };
        }

        public void Update(int tipoLeilaoId, int statusId, int enderecoId, DateTime dataHoraInicio, DateTime dataHoraFim, string urlLeilao, ICollection<Imovel>? imoveis, ICollection<Veiculo>? veiculos, decimal taxaAdministrativa, int? usuarioAprovacaoId = null)
        {
            TipoLeilaoId = tipoLeilaoId;
            StatusId = statusId;
            EnderecoId = enderecoId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            UrlLeilao = urlLeilao;
            Imoveis = imoveis;
            Veiculos = veiculos;
            TaxaAdministrativa = taxaAdministrativa;
            UsuarioAprovacaoId = usuarioAprovacaoId;
            DataHoraAtualizacao = DateTime.UtcNow;
        }

        public void AtualizarValorArrecadado(decimal valorArrecadado)
        {
            ValorArrecadado = valorArrecadado;
            DataHoraAtualizacao = DateTime.UtcNow;
        }
    }
}
