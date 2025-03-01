using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    namespace Domain.Repositories
    {
        public interface IVeiculoRepository
        {
            Task Add(Veiculo veiculo);
            Task Update(Veiculo veiculo);
            Task Remove(int id);
            Task<Veiculo> GetById(int id);
            Task<List<Veiculo>> GetAll();
            Task<List<Veiculo>> GetByLeilao(string leilaoId);
            Task<List<Veiculo>> GetByStatus(string status);
        }
    }
}
