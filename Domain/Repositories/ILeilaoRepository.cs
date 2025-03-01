﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ILeilaoRepository
    {
        Task Add(Leilao leilao);
        Task Update(Leilao leilao);
        Task Close(int id);
        Task<Leilao> GetById(int id);
        Task<List<Leilao>> GetAll();
        Task<List<Leilao>> GetByStatus(string status);
        Task<List<Leilao>> GetByTipoLeilao(string tipoLeilaoId);
    }
}