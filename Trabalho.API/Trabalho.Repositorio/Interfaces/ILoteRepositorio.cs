public interface ILoteRepositorio
{
    Task<int> CriarAsync(Lote lote);
    Task AtualizarAsync(Lote lote);    
    Task<Lote> ObterAsync(int loteId);
    Task<IEnumerable<Lote>> ListarAsync(bool Disponivel);
    Task<Lote> DeletarAsync(int loteId);
    Task<Lote> RestaurarAsync(int loteId);
}