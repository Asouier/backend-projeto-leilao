﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEnderecoRepository
    {
        Task Add(Endereco endereco);
        Task Update(Endereco endereco);
        Task Remove(int id);
        Task<Endereco> GetById(int id);
        Task<List<Endereco>> GetAll();
        Task<List<Endereco>> GetByCep(string cep);
        Task<List<Endereco>> GetByCidade(string cidade);
    }
}