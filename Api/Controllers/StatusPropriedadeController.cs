﻿using Application.DTOs.StatusPropriedades;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StatusPropriedadeController : ControllerBase
    {
        private readonly IStatusPropriedadeService _statusPropriedadeService;

        public StatusPropriedadeController(IStatusPropriedadeService statusPropriedadeService)
        {
            _statusPropriedadeService = statusPropriedadeService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddStatusPropriedade([FromBody] string novoStatusPropriedade)
        {
            var resultado = await _statusPropriedadeService.AddStatusPropriedade(novoStatusPropriedade);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateStatusPropriedade([FromBody] UpdateStatusPropriedadeDto novosDados)
        {
            var resultado = await _statusPropriedadeService.UpdateStatusPropriedade(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveStatusPropriedade(int id)
        {
            var resultado = await _statusPropriedadeService.RemoveStatusPropriedade(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetStatusPropriedadeById(int id)
        {
            var statusPropriedade = await _statusPropriedadeService.GetStatusPropriedadeById(id);
            return Ok(statusPropriedade);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStatusPropriedades()
        {
            var statusPropriedades = await _statusPropriedadeService.GetAllStatusPropriedades();
            return Ok(statusPropriedades);
        }
    }
}