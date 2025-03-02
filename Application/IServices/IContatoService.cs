using Application.DTOs.Contatos;
using Application.Models.Contatos;
using Domain.Entities;

namespace Application.IServices
{
    public interface IContatoService
    {
        Task<Contato?> GetContatoById(int id);
        Task<List<Contato>> GetAllContatos();
        Task<Contato?> GetContatoByEmail(string email);
        Task<string> AddContato(AddContatoDto contato);
        Task<string> UpdateContato(UpdateContatoDto contato);
        Task<string> RemoveContato(int id);
    }
}