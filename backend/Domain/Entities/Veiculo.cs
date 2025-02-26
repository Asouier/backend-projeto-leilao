namespace Backend.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; private set; }
        public int LeilaoId { get; private set; }
        public int TipoVeiculoId { get; private set; }
        public string Placa { get; private set; } = string.Empty;
        public string Chassi { get; private set; } = string.Empty;
        public string Marca { get; private set; } = string.Empty;
        public string Modelo { get; private set; } = string.Empty;
        public int AnoFabricacao { get; private set; }
        public string Cor { get; private set; } = string.Empty;
        public decimal ValorMinimo { get; private set; }
        public int StatusPropriedadeId { get; private set; }
        public DateTime DataHoraCadastro { get; private set; }
        public int UsuarioCadastroId { get; private set; }
        public DateTime DataRecolhimento { get; private set; }
        public string MotivoRecolhimento { get; private set; } = string.Empty;
        public int? ClienteArrematanteId { get; private set; }

        public Leilao Leilao { get; private set; } = null!;
        public TipoVeiculo TipoVeiculo { get; private set; } = null!;
        public StatusPropriedade StatusPropriedade { get; private set; } = null!;
        public Usuario UsuarioCadastro { get; private set; } = null!;
        public Cliente? ClienteArrematante { get; private set; }

        private Veiculo() { }

        public static Veiculo Create(int leilaoId, int tipoVeiculoId, string placa, string chassi, string marca, string modelo, int anoFabricacao, string cor, decimal valorMinimo, int statusPropriedadeId, int usuarioCadastroId, DateTime dataRecolhimento, string motivoRecolhimento, int? clienteArrematanteId = null)
        {
            return new Veiculo
            {
                LeilaoId = leilaoId,
                TipoVeiculoId = tipoVeiculoId,
                Placa = placa,
                Chassi = chassi,
                Marca = marca,
                Modelo = modelo,
                AnoFabricacao = anoFabricacao,
                Cor = cor,
                ValorMinimo = valorMinimo,
                StatusPropriedadeId = statusPropriedadeId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioCadastroId = usuarioCadastroId,
                DataRecolhimento = dataRecolhimento,
                MotivoRecolhimento = motivoRecolhimento,
                ClienteArrematanteId = clienteArrematanteId
            };
        }

        public void Update(int leilaoId, int tipoVeiculoId, string placa, string chassi, string marca, string modelo, int anoFabricacao, string cor, decimal valorMinimo, int statusPropriedadeId, DateTime dataRecolhimento, string motivoRecolhimento, int? clienteArrematanteId = null)
        {
            LeilaoId = leilaoId;
            TipoVeiculoId = tipoVeiculoId;
            Placa = placa;
            Chassi = chassi;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Cor = cor;
            ValorMinimo = valorMinimo;
            StatusPropriedadeId = statusPropriedadeId;
            DataRecolhimento = dataRecolhimento;
            MotivoRecolhimento = motivoRecolhimento;
            ClienteArrematanteId = clienteArrematanteId;
        }
    }
}
