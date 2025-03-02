using Application.DTOs.Permissoes;
using Domain.Entities;

namespace Application.IServices
{
    public interface IPermissaoService
    {
        Task<Permissao?> GetPermissaoById(int id);
        Task<List<Permissao>> GetAllPermissoes();
        Task<string> AddPermissao(string permissao);
        Task<string> UpdatePermissao(UpdatePermissaoDto permissao);
        Task<string> RemovePermissao(int id);
    }
}