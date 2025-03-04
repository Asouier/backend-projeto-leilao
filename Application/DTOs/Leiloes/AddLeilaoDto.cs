namespace Application.DTOs.Leiloes
{
    public class AddLeilaoDto
    {
        public required int TipoLeilaoId { get; set; }
        public int StatusId { get; set; } = 1;
        public int? EnderecoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string? UrlLeilao { get; set; }
        public required int UsuarioCadastroId { get; set; }
        public int? UsuarioAprovacaoId { get; set; }
        public decimal TaxaAdministrativa { get; set; } = 5; //Add enum para facilitar manutenção e troca do valor padrão
        public string Cep { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
    }
}
