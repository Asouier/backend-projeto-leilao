namespace Backend.Domain.Entities
{
    public class Imovel
    {
        public int Id { get; private set; }
        public int TipoImovelId { get; private set; }
        public int LeilaoId { get; private set; }
        public int EnderecoId { get; private set; }
        public decimal AreaTotal { get; private set; }
        public int QuantidadeComodos { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public int StatusPropriedadeId { get; private set; }
        public DateTime DataHoraCadastro { get; private set; }
        public int UsuarioCadastroId { get; private set; }
        public DateTime DataRecolhimento { get; private set; }
        public string MotivoRecolhimento { get; private set; } = string.Empty;
        public int? ClienteArrematanteId { get; private set; }

        public TipoImovel TipoImovel { get; private set; } = null!;
        public Leilao Leilao { get; private set; } = null!;
        public Endereco Endereco { get; private set; } = null!;
        public StatusPropriedade StatusPropriedade { get; private set; } = null!;
        public Usuario UsuarioCadastro { get; private set; } = null!;
        public Cliente? ClienteArrematante { get; private set; }

        private Imovel() { }

        public static Imovel Create(int tipoImovelId, int leilaoId, int enderecoId, decimal areaTotal, int quantidadeComodos, decimal valorMinimo, int statusPropriedadeId, int usuarioCadastroId, DateTime dataRecolhimento, string motivoRecolhimento, int? clienteArrematanteId = null)
        {
            return new Imovel
            {
                TipoImovelId = tipoImovelId,
                LeilaoId = leilaoId,
                EnderecoId = enderecoId,
                AreaTotal = areaTotal,
                QuantidadeComodos = quantidadeComodos,
                ValorMinimo = valorMinimo,
                StatusPropriedadeId = statusPropriedadeId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioCadastroId = usuarioCadastroId,
                DataRecolhimento = dataRecolhimento,
                MotivoRecolhimento = motivoRecolhimento,
                ClienteArrematanteId = clienteArrematanteId
            };
        }

        public void Update(int tipoImovelId, int leilaoId, int enderecoId, decimal areaTotal, int quantidadeComodos, decimal valorMinimo, int statusPropriedadeId, DateTime dataRecolhimento, string motivoRecolhimento, int? clienteArrematanteId = null)
        {
            TipoImovelId = tipoImovelId;
            LeilaoId = leilaoId;
            EnderecoId = enderecoId;
            AreaTotal = areaTotal;
            QuantidadeComodos = quantidadeComodos;
            ValorMinimo = valorMinimo;
            StatusPropriedadeId = statusPropriedadeId;
            DataRecolhimento = dataRecolhimento;
            MotivoRecolhimento = motivoRecolhimento;
            ClienteArrematanteId = clienteArrematanteId;
        }
    }
}
