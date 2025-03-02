using Application.DTOs.Enderecos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<string> AddEndereco(AddEnderecoDto novoEndereco)
        {
            try
            {
                var endereco = new Endereco
                {
                    Numero = novoEndereco.Numero,
                    Complemento = novoEndereco.Complemento,
                    Cidade = novoEndereco.Cidade,
                    Estado = novoEndereco.Estado,
                    Cep = novoEndereco.Cep,
                    Pais = novoEndereco.Pais
                };

                await _enderecoRepository.Add(endereco);
                return "Endereço adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar endereço: {ex.Message}";
            }
        }

        public async Task<string> UpdateEndereco(UpdateEnderecoDto novosDados)
        {
            try
            {
                var endereco = await _enderecoRepository.GetById(novosDados.Id);
                if (endereco == null)
                {
                    return "Endereço não encontrado.";
                }

                endereco.AtualizarPropriedadesNaoNulas(novosDados);

                await _enderecoRepository.Update(endereco);
                return "Endereço atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar endereço: {ex.Message}";
            }
        }

        public async Task<string> RemoveEndereco(int id)
        {
            try
            {
                var endereco = await _enderecoRepository.GetById(id);
                if (endereco == null)
                {
                    return "Endereço não encontrado.";
                }

                await _enderecoRepository.Remove(endereco.Id);
                return "Endereço removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover endereço: {ex.Message}";
            }
        }

        public async Task<Endereco?> GetEnderecoById(int id)
        {
            return await _enderecoRepository.GetById(id);
        }

        public async Task<List<Endereco>> GetAllEnderecos()
        {
            return await _enderecoRepository.GetAll();
        }

        public async Task<List<Endereco>> GetEnderecosByCep(string cep)
        {
            return await _enderecoRepository.GetByCep(cep);
        }

        public async Task<List<Endereco>> GetEnderecosByCidade(string cidade)
        {
            return await _enderecoRepository.GetByCidade(cidade);
        }
    }
}