using Application.DTOs.Enderecos;
using Application.DTOs.Imoveis;
using Application.DTOs.TipoLeiloes;
using Application.DTOs.Veiculos;

public class LeilaoDto
{
    public int Id { get; set; }
    public int TipoLeilaoId { get; set; }
    public int StatusId { get; set; }
    public int? EnderecoId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string? UrlLeilao { get; set; }
    public int UsuarioCadastroId { get; set; }
    public int? UsuarioAprovacaoId { get; set; }
    public decimal TaxaAdministrativa { get; set; }
    public decimal ValorArrecadado { get; set; }
    public string? EntidadeFinanceira { get; set; }
    public decimal IncrementoLance { get; set; }
    public DateTime DataHoraRegistro { get; set; }
    public DateTime DataHoraAtualizacao { get; set; }

    public TipoLeilaoDto TipoLeilao { get; set; }
    public List<ImovelDto> Imoveis { get; set; }
    public List<VeiculoDto> Veiculos { get; set; }
    public TipoLeilaoDto Status { get; set; }
    public UpdateEnderecoDto Endereco { get; set; }
}