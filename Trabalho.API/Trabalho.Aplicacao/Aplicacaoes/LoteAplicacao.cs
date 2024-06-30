using Trabalho.API.Repositorio;
namespace Trabalho.Aplicacao;
public class LoteAplicacao : ILoteAplicacao
{
    private readonly ILoteRepositorio _loteRepositorio;
    public LoteAplicacao(ILoteRepositorio loteRepositorio)
    {
        _loteRepositorio = loteRepositorio;
    }

    public async Task AtualizarAsync(Lote lote)
    {
        var loteDominio = await _loteRepositorio.ObterAsync(lote.Id);

        if (loteDominio == null)
        {
            throw new Exception("Lote Inválido");
        }

        loteDominio = lote;

        await _loteRepositorio.AtualizarAsync(loteDominio);

    }

    public async Task<int> CriarAsync(Lote lote)
    {
        if (lote == null)
        {
            throw new Exception("Lote não pode ser Vazio");
        }

        var loteDominio = await _loteRepositorio.ObterAsync(lote.Id);

        if (loteDominio != null)
        {
            throw new Exception("Lote Inválido");
        }

        var loteId = await _loteRepositorio.CriarAsync(lote);

        return loteId;
    }

    public async Task<IEnumerable<Lote>> ListarAsync(bool ativo)
    {
        var lista = await _loteRepositorio.ListarAsync(ativo);

        if (lista == null)
        {
            throw new Exception("Não há registros de Lotes ativos");
        }

        return lista;
    }


    public async Task<Lote> ObterAsync(int loteId)
    {
        var lote = await _loteRepositorio.ObterAsync(loteId);
        if (lote == null)
        {
            throw new Exception("Lote não existe");
        }
        return lote;
    }

    public async Task DeletarAsync(int loteId)
    {
        var lote = await _loteRepositorio.ObterAsync(loteId);
        if (lote == null)
        {
            throw new Exception("Lote não existe");
        }

        if (lote.Disponivel == false)
        {
            throw new Exception("Lote Inativo");
        }

        lote.DeletarDisponibilidade();
        await _loteRepositorio.AtualizarAsync(lote);
    }
    public async Task RestaurarAsync(int loteId)
    {
        var lote = await _loteRepositorio.ObterAsync(loteId);
        if (lote.Disponivel == true)
        {
            throw new Exception("Lote Disponível");
        }

        lote.RestaurarDisponibilidade();
        await _loteRepositorio.AtualizarAsync(lote);

    }

}