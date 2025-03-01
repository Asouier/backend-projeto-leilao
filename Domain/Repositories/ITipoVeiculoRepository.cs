using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITipoVeiculoRepository
    {
        Task Add(TipoVeiculo tipoVeiculo);
        Task Update(TipoVeiculo tipoVeiculo);
        Task Remove(int id);
        Task<TipoVeiculo> GetById(int id);
        Task<List<TipoVeiculo>> GetAll();
    }
}
