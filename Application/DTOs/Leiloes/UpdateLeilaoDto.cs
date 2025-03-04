namespace Application.DTOs.Leiloes
{
    public class UpdateLeilaoDto
    {
        public int Id { get; set; }
        public int? TipoLeilaoId { get; set; }
        public int? StatusId { get; set; }
        public int? EnderecoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string? UrlLeilao { get; set; }
        public int? UsuarioAprovacaoId { get; set; }
        public decimal? TaxaAdministrativa { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
    }
}
