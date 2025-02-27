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
        Task Remove(string id);
        Task<RepresentanteLegal> GetById(string id);
        Task<List<RepresentanteLegal>> GetAll();
        Task<RepresentanteLegal> GetByCpf(string cpf);
    }
}