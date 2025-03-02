using Application.DTOs.Clientes;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<string> AddCliente(AddClienteDto novoCliente)
        {
            try
            {
                var cliente = new Cliente
                {
                    CredencialId = novoCliente.CredencialId,
                    Rg = novoCliente.Rg,
                    OrgaoEmissor = novoCliente.OrgaoEmissor,
                    Cpf = novoCliente.Cpf,
                    Cnpj = novoCliente.Cnpj,
                    NomeCompleto = novoCliente.NomeCompleto,
                    NomeFantasia = novoCliente.NomeFantasia,
                    RazaoSocial = novoCliente.RazaoSocial,
                    RepresentanteLegalId = novoCliente.RepresentanteLegalId,
                    EnderecoId = novoCliente.EnderecoId,
                    ContatoId = novoCliente.ContatoId,
                    Certidao = novoCliente.Certidao
                };

                await _clienteRepository.Add(cliente);
                return "Cliente adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar cliente: {ex.Message}";
            }
        }

        public async Task<string> UpdateCliente(UpdateClienteDto novosDados)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(novosDados.Id);
                if (cliente == null)
                {
                    return "Cliente não encontrado.";
                }

                cliente.AtualizarPropriedadesNaoNulas(novosDados);

                await _clienteRepository.Update(cliente);
                return "Cliente atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar cliente: {ex.Message}";
            }
        }

        public async Task<string> RemoveCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(id);
                if (cliente == null)
                {
                    return "Cliente não encontrado.";
                }

                await _clienteRepository.Remove(cliente.Id);
                return "Cliente removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover cliente: {ex.Message}";
            }
        }

        public async Task<Cliente?> GetClienteById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<List<Cliente>?> GetClientesByNome(string nome)
        {
            return await _clienteRepository.GetByNome(nome);
        }

        public async Task<List<Cliente>?> GetClientesByCpf(string cpf)
        {
            return await _clienteRepository.GetByCpf(cpf);
        }

        public async Task<List<Cliente>?> GetClientesByCnpj(string cnpj)
        {
            return await _clienteRepository.GetByCnpj(cnpj);
        }
    }
}