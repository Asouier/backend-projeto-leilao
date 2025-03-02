using Application.DTOs.Contatos;
using Application.Models.Contatos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class ContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<string> AddContato(AddContatoDto novoContato)
        {
            try
            {
                var contato = new Contato
                {
                    Email = novoContato.Email,
                    Telefone = novoContato.Telefone,
                };

                await _contatoRepository.Add(contato);
                return "Contato adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar contato: {ex.Message}";
            }
        }

        public async Task<string> UpdateContato(UpdateContatoDto novosDados)
        {
            try
            {
                var contato = await _contatoRepository.GetById(novosDados.Id);
                if (contato == null)
                {
                    return "Contato não encontrado.";
                }

                contato.AtualizarPropriedadesNaoNulas(novosDados);

                await _contatoRepository.Update(contato);
                return "Contato atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar contato: {ex.Message}";
            }
        }

        public async Task<string> RemoveContato(int id)
        {
            try
            {
                var contato = await _contatoRepository.GetById(id);
                if (contato == null)
                {
                    return "Contato não encontrado.";
                }

                await _contatoRepository.Remove(contato.Id);
                return "Contato removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover contato: {ex.Message}";
            }
        }

        public async Task<Contato?> GetContatoById(int id)
        {
            return await _contatoRepository.GetById(id);
        }

        public async Task<List<Contato>> GetAllContatos()
        {
            return await _contatoRepository.GetAll();
        }

        public async Task<Contato?> GetContatoByEmail(string email)
        {
            return await _contatoRepository.GetByEmail(email);
        }
    }
}