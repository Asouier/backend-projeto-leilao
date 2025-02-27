using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface LeilaoRepository
    {
        Task Add(Leilao leilao);
        Task Update(Leilao leilao);
        Task Close(string id);
        Task<Leilao> GetById(string id);
        Task<List<Leilao>> GetAll();
        Task<List<Leilao>> GetByStatus(string status);
        Task<List<Leilao>> GetByTipoLeilao(string tipoLeilaoId);
    }
}