using Microsoft.AspNetCore.Mvc;
using Trabalho.API;

namespace Trabalho.Api;

[ApiController]
[Route("[controller]")]
public class LoteController : ControllerBase
{
    private readonly ILoteAplicacao _loteAplicacao;

    public LoteController(ILoteAplicacao loteAplicacao)
    {
        _loteAplicacao = loteAplicacao;
    }

    [HttpGet]
    [Route("HealthCheck")]
    public IActionResult HealthCheck()
    {
        return Ok("OK");
    }

    [HttpGet]
    [Route("Listar")]
    public async Task<IActionResult> Listar(bool ativo)
    {
        try
        {
            var lista = await _loteAplicacao.ListarAsync(ativo);

            var lotes = lista.Select(lote => new LoteResposta()
            {
                Rua = lote.Rua,
                Numero = lote.Numero,
                Valor = lote.Valor,
                Tamanho = lote.Tamanho,
                Disponivel = lote.Disponivel,
            }).ToList();

            return Ok(lotes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Obter/{loteId}")]
    public async Task<IActionResult> Obter([FromRoute] int loteId)
    {
        try
        {
            var loteDominio = await _loteAplicacao.ObterAsync(loteId);

            var loteDetalhado = new LoteDetalhado()
            {
                Rua = loteDominio.Rua,
                Numero = loteDominio.Numero,
                Valor = loteDominio.Valor,
                Tamanho = loteDominio.Tamanho,
                Disponivel = loteDominio.Disponivel,
            };

            return Ok(loteDetalhado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Criar")]
    public async Task<IActionResult> Criar([FromBody] LoteCriar loteCriar)
    {
        try
        {
            if (string.IsNullOrEmpty(loteCriar.Rua))
            {
                return BadRequest("Rua não pode ser nula ou vazia.");
            }

            var loteDominio = new Lote(loteCriar.Rua, loteCriar.Numero, loteCriar.Valor, loteCriar.Tamanho);

            var loteId = await _loteAplicacao.CriarAsync(loteDominio);

            return Ok(loteId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }
    [HttpPut]
    [Route("Atualizar/{loteId}")]
    public async Task<IActionResult> AtualizarCliente([FromBody] LoteAtualizar lote, [FromRoute] int loteId)
    {
        try
        {
            var loteAtualizar = await _loteAplicacao.ObterAsync(loteId);

            if (loteAtualizar == null)
            {
                return NotFound("Lote não encontrado.");
            }

            await _loteAplicacao.AtualizarAsync(loteAtualizar);

            return Ok(loteAtualizar);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar/{loteId}")]
    public async Task<IActionResult> Deletar([FromRoute] int loteId)
    {
        try
        {
            await _loteAplicacao.DeletarAsync(loteId);

            return Ok("Lote Deletado");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Restaurar/{loteId}")]
    public async Task<IActionResult> Restaurar([FromRoute] int loteId)
    {
        try
        {
            await _loteAplicacao.RestaurarAsync(loteId);
            return Ok("Lote Restaurado");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}