using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Trabalho.API.Repositorio;
using Trabalho.Repositorio;

public class ClienteRepositorio : BaseRepositorio, IClienteRepositorio
{
    public ClienteRepositorio(TrabalhoContexto contexto) : base(contexto) { }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _contexto.Update(cliente);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Cliente>> ListarAsync(bool ativo)
    {
        return await Task.FromResult(_contexto.Clientes
                                    .Where(cliente => cliente.Ativo == ativo));
    }

    public async Task<Cliente> ObterAsync(int clienteId)
{
    var cliente = await _contexto.Clientes
                                .Where(cliente => cliente.Id == clienteId)
                                .FirstOrDefaultAsync();

    if (cliente == null)
    {
        throw new InvalidOperationException($"Cliente com ID {clienteId} não encontrado.");
    }

    return cliente;
}

    public async Task<Cliente> ObterPorEmailAsync(string email)
    {
        var cliente = await _contexto.Clientes
                                    .Where(cliente => cliente.Email == email)
                                    .FirstOrDefaultAsync();

        return cliente;
    }

    public async Task<int> CriarAsync(Cliente cliente)
    {
        await _contexto.Clientes.AddAsync(cliente);
        await _contexto.SaveChangesAsync();
        return cliente.Id;
    }

    public async Task<Cliente> DeletarAsync(int clienteId)
    {
        var cliente = await _contexto.Clientes
                                    .Where(cliente => cliente.Id == clienteId)
                                    .FirstOrDefaultAsync();

        if (cliente != null)
        {
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
        }

        return cliente;
    }

    public async Task<Cliente> RestaurarAsync(int clienteId)
{
    var cliente = await _contexto.Clientes
                                .Where(cliente => cliente.Id == clienteId)
                                .FirstOrDefaultAsync();
    if (cliente != null)
    {
        cliente.Ativo = true; 
        _contexto.Clientes.Update(cliente);
        await _contexto.SaveChangesAsync();
        return cliente;
    }

    return null; 
}
}