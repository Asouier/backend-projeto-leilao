using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepresentanteLegalRepository
    {
        Task Add(RepresentanteLegal representanteLegal);
        Task Update(RepresentanteLegal representanteLegal);
        Task Remove(int id);
        Task<RepresentanteLegal> GetById(int id);
        Task<List<RepresentanteLegal>> GetAll();
        Task<RepresentanteLegal> GetByCpf(string cpf);
    }
}