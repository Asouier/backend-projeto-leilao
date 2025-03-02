using Application.DTOs.Clientes;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddCliente([FromBody] AddClienteDto novoCliente)
        {
            var resultado = await _clienteService.AddCliente(novoCliente);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateCliente([FromBody] UpdateClienteDto novosDados)
        {
            var resultado = await _clienteService.UpdateCliente(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveCliente(int id)
        {
            var resultado = await _clienteService.RemoveCliente(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            return Ok(cliente);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("filtrar-por-nome/{nome}")]
        public async Task<IActionResult> GetClientesByNome(string nome)
        {
            var clientes = await _clienteService.GetClientesByNome(nome);
            return Ok(clientes);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetClientesByCpf(string cpf)
        {
            var clientes = await _clienteService.GetClientesByCpf(cpf);
            return Ok(clientes);
        }

        [HttpGet("cnpj/{cnpj}")]
        public async Task<IActionResult> GetClientesByCnpj(string cnpj)
        {
            var clientes = await _clienteService.GetClientesByCnpj(cnpj);
            return Ok(clientes);
        }

        [HttpGet("registro/{credencialId}")]
        public async Task<IActionResult> GetClienteByCredencialId(int credencialId)
        {
            var clientes = await _clienteService.GetClienteByCredencialId(credencialId);
            return Ok(clientes);
        }
    }
}