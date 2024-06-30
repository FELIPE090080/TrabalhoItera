public interface IClienteAplicacao
{
    Task AtualizarAsync(Cliente cliente);
    Task<int> CriarAsync(Cliente cliente);
    Task<IEnumerable<Cliente>> ListarAsync(bool ativo);
    Task<Cliente> ObterPorEmailAsync(string email);
    Task<Cliente> ObterAsync(int clienteId);
    Task<int> LogarAsync(string email, string senha);
    Task AlterarSenhaAsync(string email, string senhaAtual, string novaSenha);
    Task DeletarAsync(int clienteId);
    Task RestaurarAsync(int clienteId);
}