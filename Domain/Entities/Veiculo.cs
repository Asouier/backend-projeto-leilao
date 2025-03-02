namespace Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int LeilaoId { get; set; }
        public int TipoVeiculoId { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; } = string.Empty;
        public decimal ValorMinimo { get; set; }
        public int StatusPropriedadeId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioCadastroId { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string MotivoRecolhimento { get; set; } = string.Empty;
        public int? ClienteArrematanteId { get; set; }

        public Leilao Leilao { get; set; } = null!;
        public TipoVeiculo TipoVeiculo { get; set; } = null!;
        public StatusPropriedade StatusPropriedade { get; set; } = null!;
        public Usuario UsuarioCadastro { get; set; } = null!;
        public Cliente? ClienteArrematante { get; set; }

        public Veiculo() { }

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
