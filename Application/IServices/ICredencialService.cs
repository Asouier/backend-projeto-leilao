﻿using Application.DTOs.Credenciais;
using Domain.Entities;

namespace Application.IServices
{
    public interface ICredencialService
    {
        Task<Credencial?> GetCredencialById(int id);
        Task<ResponseLoginDto?> GetAccess(LoginDto credencial);
        Task<Credencial?> GetCredencialByNomeUsuario(string nomeUsuario);
        Task<string> AddCredencial(AddCredencialDto credencial);
        Task<string> UpdateCredencial(UpdateCredencialDto credencial);
        Task<string> RemoveCredencial(int id);
    }
}