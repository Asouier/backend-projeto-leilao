namespace Domain.Entities
{
    public class Imovel
    {
        public int Id { get; set; }
        public int TipoImovelId { get; set; }
        public int LeilaoId { get; set; }
        public int EnderecoId { get; set; }
        public decimal AreaTotal { get; set; }
        public int? QuantidadeComodos { get; set; }
        public decimal ValorMinimo { get; set; }
        public int StatusPropriedadeId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioCadastroId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string MotivoRecolhimento { get; set; } = string.Empty;
        public int? ClienteArrematanteId { get; set; }

        public TipoImovel TipoImovel { get; set; } = null!;
        public Leilao Leilao { get; set; } = null!;
        public Endereco Endereco { get; set; } = null!;
        public StatusPropriedade StatusPropriedade { get; set; } = null!;
        public Usuario UsuarioCadastro { get; set; } = null!;
        public Cliente? ClienteArrematante { get; set; }

        public Imovel() { }

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
