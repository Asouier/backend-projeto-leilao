namespace Domain.Entities
{
    public class Leilao
    {
        public int Id { get; set; }
        public int TipoLeilaoId { get; set; }
        public int StatusId { get; set; }
        public int? EnderecoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string? UrlLeilao { get; set; } = string.Empty;
        public int UsuarioCadastroId { get; set; }
        public int? UsuarioAprovacaoId { get; set; }
        public decimal TaxaAdministrativa { get; set; }
        public decimal ValorArrecadado { get; set; }
        public string? EntidadeFinanceira { get; set; } 
        public decimal IncrementoLance { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }

        public TipoLeilao TipoLeilao { get; set; } = null!;
        public ICollection<Imovel>? Imoveis { get; set; }
        public ICollection<Veiculo>? Veiculos { get; set; }
        public StatusLeilao Status { get; set; } = null!;
        public Endereco Endereco { get; set; } = null!;
        public Usuario UsuarioCadastro { get; set; } = null!;
        public Usuario? UsuarioAprovacao { get; set; }

        public Leilao() { }

        public static Leilao Create(int tipoLeilaoId, int statusId, int enderecoId, DateTime dataHoraInicio, DateTime dataHoraFim, string urlLeilao, ICollection<Imovel>? imoveis, ICollection<Veiculo>? veiculos, int usuarioCadastroId, decimal taxaAdministrativa, int? usuarioAprovacaoId = null, string? entidadeFinanceira = null)
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
                EntidadeFinanceira = entidadeFinanceira,
                IncrementoLance = 0,
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
