using Microsoft.AspNetCore.Mvc;
using Trabalho.API;

namespace Trabalho.Api;

[ApiController]
[Route("[controller]")]
public class AdministradorController : ControllerBase
{
    private readonly IAdministradorAplicacao _administradorAplicacao;

    public AdministradorController(IAdministradorAplicacao administradorAplicacao)
    {
        _administradorAplicacao = administradorAplicacao;
    }

    [HttpGet]
    [Route("HealthCheck")]
    public IActionResult HealthCheck()
    {
        return Ok("OK");
    }

    [HttpPost]
    [Route("Criar")]
    public async Task<IActionResult> Criar([FromBody] AdministradorCriar administradorCriar)
    {
        try
        {
            var administrador = new Administrador(administradorCriar.Nome, administradorCriar.Email, administradorCriar.Senha);
            int administradorId = await _administradorAplicacao.CriarAsync(administrador);

            return Ok(administradorId);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.GetType().Name}  -  {ex.Message}");
        }
    }

    [HttpPut]
    [Route("Atualizar/{administradorId}")]
    public async Task<IActionResult> AtualizarAdministrador([FromBody] AdministradorAtualizar administrador, [FromRoute] int administradorId)
    {
        try
        {
            var administradorAtualizar = await _administradorAplicacao.ObterAsync(administradorId);

            if (administradorAtualizar == null)
            {
                return NotFound("Administrador não encontrado.");
            }

            if (administrador.Email != null)
            {
                administradorAtualizar.Email = administrador.Email;
            }

            if (administrador.Senha != null)
            {
                administradorAtualizar.Senha = administrador.Senha;
            }

            await _administradorAplicacao.AtualizarAsync(administradorAtualizar);

            return Ok(administradorAtualizar);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Logar")]
    public async Task<IActionResult> Logar([FromBody] AdministradorAutenticar administrador)
    {
        try
        {
            var administradorId = await _administradorAplicacao.LogarAsync(administrador.Email, administrador.Senha);

            var administradorDominio = await _administradorAplicacao.ObterAsync(administradorId);

            var administradorLogado = new AdministradorLogado()
            {
                Id = administradorDominio.Id,
                Nome = administradorDominio.Nome,
                Email = administradorDominio.Email,
            };

            return Ok(administradorLogado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}