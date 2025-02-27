using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface TipoVeiculoRepository
    {
        Task Add(TipoVeiculo tipoVeiculo);
        Task Update(TipoVeiculo tipoVeiculo);
        Task Remove(string id);
        Task<TipoVeiculo> GetById(string id);
        Task<List<TipoVeiculo>> GetAll();
    }
}
