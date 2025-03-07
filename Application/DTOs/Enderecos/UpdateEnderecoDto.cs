﻿namespace Application.DTOs.Enderecos
{
    public class UpdateEnderecoDto
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Descricao { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
