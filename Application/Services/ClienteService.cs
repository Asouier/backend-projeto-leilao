using Application.DTOs.Clientes;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data.Persistence;

namespace Domain.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly AppDbContext _context;

        public ClienteService(IClienteRepository clienteRepository, AppDbContext context)
        {
            _clienteRepository = clienteRepository;
            _context = context;
        }

        public async Task<string> AddCliente(AddClienteDto novoCliente)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var novaCredencial = new Credencial()
                {
                    NomeUsuario = novoCliente.NomeUsuario,
                    Senha = novoCliente.Senha
                };
                _context.Credenciais.Add(novaCredencial);
                await _context.SaveChangesAsync();

                var novoEndereco = new Endereco()
                {
                    Cep = novoCliente.Cep,
                    Descricao = novoCliente.Endereco,
                    Cidade = novoCliente.Cidade,
                    Estado = novoCliente.Estado,
                    Pais = novoCliente.Pais,
                    Numero = novoCliente.Numero
                };
                _context.Enderecos.Add(novoEndereco);
                await _context.SaveChangesAsync();

                var novoContato = new Contato()
                {
                    Telefone = novoCliente.Telefone,
                    Email = novoCliente.Email
                };
                _context.Contatos.Add(novoContato);
                await _context.SaveChangesAsync();

                var cliente = new Cliente
                {
                    CredencialId = novaCredencial.Id,
                    Rg = novoCliente.Rg,
                    OrgaoEmissor = novoCliente.OrgaoEmissor,
                    Cpf = novoCliente.Cpf,
                    Cnpj = novoCliente.Cnpj,
                    NomeCompleto = novoCliente.NomeCompleto,
                    NomeFantasia = novoCliente.NomeFantasia,
                    RazaoSocial = novoCliente.RazaoSocial,
                    EnderecoId = novoEndereco.Id,
                    ContatoId = novoContato.Id,
                    Certidao = novoCliente.Certidao
                };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return $"Cliente com usuario:{novoCliente.NomeUsuario} foi adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
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