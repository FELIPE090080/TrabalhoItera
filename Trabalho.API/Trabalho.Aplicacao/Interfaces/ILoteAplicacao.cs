public interface ILoteAplicacao
{
    Task AtualizarAsync(Lote lote);
    Task<int> CriarAsync(Lote lote);
    Task<IEnumerable<Lote>> ListarAsync(bool ativo);
    Task<Lote> ObterAsync(int loteId);
    Task DeletarAsync(int loteId);
    Task RestaurarAsync(int loteId);
}