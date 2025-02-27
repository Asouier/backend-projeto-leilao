using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ImovelRepository
    {
        Task Add(Imovel imovel);
        Task Update(Imovel imovel);
        Task Remove(string id);
        Task<Imovel> GetById(string id);
        Task<List<Imovel>> GetAll();
        Task<List<Imovel>> GetByLeilao(string leilaoId);
        Task<List<Imovel>> GetByStatus(string status);
    }
}
