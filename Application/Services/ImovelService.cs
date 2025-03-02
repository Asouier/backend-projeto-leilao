using Application.DTOs.Imoveis;
using Application.Models.Imoveis;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data.Repositories;

namespace Domain.Services
{
    public class ImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly ILeilaoRepository _leilaoRepository;

        public ImovelService(IImovelRepository imovelRepository, ILeilaoRepository leilaoRepository)
        {
            _imovelRepository = imovelRepository;
            _leilaoRepository = leilaoRepository;
        }

        public async Task<string> AddImovel(AddImovelDto novoImovel)
        {
            try
            {
                var imovel = new Imovel
                {
                    TipoImovelId = novoImovel.TipoImovelId,
                    LeilaoId = novoImovel.LeilaoId,
                    EnderecoId = novoImovel.EnderecoId,
                    AreaTotal = novoImovel.AreaTotal,
                    QuantidadeComodos = novoImovel.QuantidadeComodos,
                    ValorMinimo = novoImovel.ValorMinimo,
                    StatusPropriedadeId = novoImovel.StatusPropriedadeId,
                    UsuarioCadastroId = novoImovel.UsuarioCadastroId,
                    DataRecolhimento = novoImovel.DataRecolhimento,
                    MotivoRecolhimento = novoImovel.MotivoRecolhimento
                };

                await _imovelRepository.Add(imovel);
                return "Imóvel adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar imóvel: {ex.Message}";
            }
        }

        public async Task<string> UpdateImovel(UpdateImovelDto novosDados)
        {
            try
            {
                var imovel = await _imovelRepository.GetById(novosDados.Id);
                if (imovel == null)
                {
                    return "Imóvel não encontrado.";
                }

                var anfitriao = await _leilaoRepository.GetById(imovel.LeilaoId);
                if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";

                imovel.AtualizarPropriedadesNaoNulas(novosDados);

                await _imovelRepository.Update(imovel);
                return "Imóvel atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar imóvel: {ex.Message}";
            }
        }

        public async Task<string> NovoLance(NovoLanceDto informacoesLance)
        {
            try
            {
                var imovel = await _imovelRepository.GetById(informacoesLance.IdImovel);
                if (imovel == null)
                {
                    return "Veículo não encontrado.";
                }

                var anfitriao = await _leilaoRepository.GetById(imovel.LeilaoId);
                if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";
                if (anfitriao.StatusId != 1) // Trocar para um enum
                {
                    return "O Leilão anfitrião não esta mais disponivel, logo não haverão mudanças nas informações do Veiculo";
                }

                if (informacoesLance.ValorDoLance < imovel.ValorMinimo)
                {
                    return "Esse tipo de alteração viola a política de uso do Leilão. Um representante do Leilão entrará em contato com você em breve.";
                    //Adicionar log
                }

                imovel.AtualizarPropriedadesNaoNulas(informacoesLance);

                await _imovelRepository.Update(imovel);
                return "Veículo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar veículo: {ex.Message}";
            }
        }

        public async Task<string> RemoveImovel(int id)
        {
            var imovel = await _imovelRepository.GetById(id);
            
            if (imovel == null) return "Imóvel não encontrado.";
            
            if (imovel.StatusPropriedade.Id != 1)
                return "Apenas Imóveis com status disponível podem ser removidos.";
            
            try
            {
                await _imovelRepository.Remove(imovel.Id);
                return "Imóvel removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover imóvel: {ex.Message}";
            }
        }

        public async Task<Imovel?> GetImovelById(int id)
        {
            return await _imovelRepository.GetById(id);
        }

        public async Task<List<Imovel>> GetAllImoveis()
        {
            return await _imovelRepository.GetAll();
        }

        public async Task<List<Imovel>> GetImoveisByLeilao(int leilaoId)
        {
            return await _imovelRepository.GetByLeilao(leilaoId);
        }

        public async Task<List<Imovel>> GetImoveisByStatus(int statusId)
        {
            return await _imovelRepository.GetByStatus(statusId);
        }
    }
}