using Microsoft.AspNetCore.Mvc;
using Trabalho.API;

namespace Trabalho.Api;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteAplicacao _clienteAplicacao;

    public ClienteController(IClienteAplicacao clienteAplicacao)
    {
        _clienteAplicacao = clienteAplicacao;
    }

    [HttpGet]
    [Route("HealthCheck")]
    public IActionResult HealthCheck()
    {
        return Ok("OK");
    }

    [HttpGet]
    [Route("Listar")]
    public async Task<IActionResult> Listar([FromQuery] bool ativo)
    {
        try
        {
            var lista = await _clienteAplicacao.ListarAsync(ativo);

            var clientes = lista.Select(cliente => new ClienteResposta()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
            }).ToList();

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Obter/{clienteId}")]
    public async Task<IActionResult> ObterPorId([FromRoute] int clienteId)
    {
        try
        {
            var clienteDominio = await _clienteAplicacao.ObterAsync(clienteId);

            var clienteDetalhado = new ClienteDetalhado()
            {
                Id = clienteDominio.Id,
                Nome = clienteDominio.Nome,
                Email = clienteDominio.Email,
                Lotes = clienteDominio.Lotes,
                Ativo = clienteDominio.Ativo,
            };

            return Ok(clienteDetalhado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Criar")]
    public async Task<IActionResult> Criar([FromBody] ClienteCriar clienteCriar)
    {
        try
        {
            var clienteDominio = new Cliente(clienteCriar.Nome, clienteCriar.Email, clienteCriar.Senha);

            var clienteId = await _clienteAplicacao.CriarAsync(clienteDominio);

            return Ok(clienteId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar/{clienteId}")]
    public async Task<IActionResult> Atualizar([FromRoute] int clienteId, [FromBody] ClienteAtualizar cliente)
    {
        try
        {
            var clienteDominio = await _clienteAplicacao.ObterAsync(clienteId);

            clienteDominio = new Cliente()
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
            };

            await _clienteAplicacao.AtualizarAsync(clienteDominio);

            return Ok(clienteDominio);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut]
    [Route("AlterarSenha")]
    public async Task<IActionResult> AlterarSenha([FromBody] ClienteAlterarSenha cliente)
    {
        try
        {
            await _clienteAplicacao.AlterarSenhaAsync(cliente.Email, cliente.SenhaAtual, cliente.NovaSenha);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Logar")]
    public async Task<IActionResult> Logar([FromBody] ClienteAutenticar cliente)
    {
        try
        {
            var clienteId = await _clienteAplicacao.LogarAsync(cliente.Email, cliente.Senha);

            var clienteDominio = await _clienteAplicacao.ObterAsync(clienteId);

            var clienteLogado = new ClienteLogado()
            {
                Id = clienteDominio.Id,
                Nome = clienteDominio.Nome,
                Email = clienteDominio.Email,
                Lotes = clienteDominio.Lotes.ToList(), 
            };

            return Ok(clienteLogado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Restaurar/{clienteId}")]
    public async Task<IActionResult> Restaurar([FromRoute] int clienteId)
    {
        try
        {
            await _clienteAplicacao.RestaurarAsync(clienteId);
            return Ok("Cliente Restaurado");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar/{clienteId}")]
    public async Task<IActionResult> Deletar([FromRoute] int clienteId)
    {
        try
        {
            await _clienteAplicacao.DeletarAsync(clienteId);

            return Ok("Cliente Deletado");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}