using Application.DTOs.RepresentantesLegais;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class RepresentanteLegalService: IRepresentanteLegalService
    {
        private readonly IRepresentanteLegalRepository _representanteLegalRepository;

        public RepresentanteLegalService(IRepresentanteLegalRepository representanteLegalRepository)
        {
            _representanteLegalRepository = representanteLegalRepository;
        }

        public async Task<string> AddRepresentanteLegal(AddRepresentanteLegalDto novoRepresentanteLegal)
        {
            try
            {
                var representanteLegal = RepresentanteLegal.Create(
                    novoRepresentanteLegal.Nome,
                    novoRepresentanteLegal.Cpf,
                    novoRepresentanteLegal.DocumentoIdentificacao,
                    novoRepresentanteLegal.ContatoId
                );

                await _representanteLegalRepository.Add(representanteLegal);
                return "Representante legal adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar representante legal: {ex.Message}";
            }
        }

        public async Task<string> UpdateRepresentanteLegal(UpdateRepresentanteLegalDto novosDados)
        {
            try
            {
                var representanteLegal = await _representanteLegalRepository.GetById(novosDados.Id);
                if (representanteLegal == null)
                {
                    return "Representante legal não encontrado.";
                }

                representanteLegal.AtualizarPropriedadesNaoNulas(novosDados);

                await _representanteLegalRepository.Update(representanteLegal);
                return "Representante legal atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar representante legal: {ex.Message}";
            }
        }

        public async Task<string> RemoveRepresentanteLegal(int id)
        {
            try
            {
                var representanteLegal = await _representanteLegalRepository.GetById(id);
                if (representanteLegal == null)
                {
                    return "Representante legal não encontrado.";
                }

                await _representanteLegalRepository.Remove(representanteLegal.Id);
                return "Representante legal removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover representante legal: {ex.Message}";
            }
        }

        public async Task<RepresentanteLegal?> GetRepresentanteLegalById(int id)
        {
            return await _representanteLegalRepository.GetById(id);
        }

        public async Task<RepresentanteLegal?> GetRepresentanteLegalByCpf(string cpf)
        {
            return await _representanteLegalRepository.GetByCpf(cpf);
        }
    }
}