using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Trabalho.API.Repositorio;
using Trabalho.Repositorio;

public class LoteRepositorio : BaseRepositorio, ILoteRepositorio
{
    public LoteRepositorio(TrabalhoContexto contexto) : base(contexto) { }

    public async Task AtualizarAsync(Lote lote)
    {
        _contexto.Update(lote);
        await _contexto.SaveChangesAsync();

    }

    public async Task<IEnumerable<Lote>> ListarAsync(bool ativo)
    {
        return await Task.FromResult(_contexto.Lotes
                                    .Where(Lote => Lote.Disponivel == ativo));
    }

    public async Task<Lote> ObterAsync(int loteId)
    {
        return await _contexto.Lotes
                                    .Where(lote => lote.Id == loteId)
                                    .FirstOrDefaultAsync();
    }


    public async Task<int> CriarAsync(Lote lote)
    {
        await _contexto.Lotes.AddAsync(lote);
        await _contexto.SaveChangesAsync();
        return lote.Id;

    }

    public async Task<Lote> DeletarAsync(int loteId)
    {
        var lote = await _contexto.Lotes
                                    .Where(lote => lote.Id == loteId)
                                    .FirstOrDefaultAsync();

        if (lote != null)
        {
            _contexto.Lotes.Remove(lote);
            lote.Disponivel = false;
            await _contexto.SaveChangesAsync();
        }

        return lote;
    }

    public async Task<Lote?> RestaurarAsync(int loteID)
    {
        var lote = await _contexto.Lotes
                                .Where(lote => lote.Id == loteID)
                                .FirstOrDefaultAsync();
        if (lote != null)
        {
            lote.Disponivel = true;
            _contexto.Lotes.Update(lote);
            await _contexto.SaveChangesAsync();
            return lote;
        }

        return null;
    }
}

