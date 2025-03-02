using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IImovelRepository
    {
        Task Add(Imovel imovel);
        Task Update(Imovel imovel);
        Task Remove(int id);
        Task<Imovel?> GetById(int id);
        Task<List<Imovel>> GetAll();
        Task<List<Imovel>> GetByLeilao(int leilaoId);
        Task<List<Imovel>> GetByStatus(int statusId);
    }
}
