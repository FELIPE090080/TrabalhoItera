namespace Trabalho.API.Repositorio;

public interface IClienteRepositorio
{
    Task<int> CriarAsync(Cliente cliente);
    Task AtualizarAsync(Cliente cliente);
    Task<Cliente> ObterAsync(int clienteId);
    Task<Cliente> ObterPorEmailAsync(string email);
    Task<IEnumerable<Cliente>> ListarAsync(bool ativo);
    Task<Cliente> DeletarAsync(int clienteId);
    Task<Cliente> RestaurarAsync(int clienteId);
}