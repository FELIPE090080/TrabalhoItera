using Trabalho.API.Repositorio;


namespace Trabalho.Aplicacao;
public class ClienteAplicacao : IClienteAplicacao
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteAplicacao(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;

    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        var clienteDominio = await _clienteRepositorio.ObterAsync(cliente.Id);

        if (clienteDominio == null)
        {
            throw new Exception("Cliente Inválido");
        }

        clienteDominio = cliente;

        await _clienteRepositorio.AtualizarAsync(clienteDominio);

    }
    public async Task<int> CriarAsync(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new Exception("Cliente não pode ser Vazio");
        }

        var clienteDominio = await _clienteRepositorio.ObterPorEmailAsync(cliente.Email);

        if (clienteDominio != null)
        {
            throw new Exception("Email Inválido");
        }

        var clienteId = await _clienteRepositorio.CriarAsync(cliente);

        return clienteId;
    }
    public async Task<IEnumerable<Cliente>> ListarAsync(bool ativo)
    {
        var lista = await _clienteRepositorio.ListarAsync(ativo);

        if (lista == null)
        {
            throw new Exception("Não há registros de Clientes ativos");
        }

        return lista;
    }
    public async Task<Cliente> ObterPorEmailAsync(string email)
    {
        var clienteDominio = await _clienteRepositorio.ObterPorEmailAsync(email);

        if (clienteDominio == null)
        {
            throw new Exception("Cliente não encontrado");
        }

        return clienteDominio;
    }
    public async Task<Cliente> ObterAsync(int clienteId)
    {
        var cliente = await _clienteRepositorio.ObterAsync(clienteId);
        if (cliente == null)
        {
            throw new Exception("Cliente não existe");
        }
        return cliente;
    }
    public async Task<int> LogarAsync(string email, string senha)
    {

        if (email == null)
        {
            throw new Exception("Email e/ou Senha inválidos");
        }

        var clienteDominio = await _clienteRepositorio.ObterPorEmailAsync(email);

        if (clienteDominio.Senha != senha)
        {
            throw new Exception("Email e/ou Senha inválidos");
        }

        return clienteDominio.Id;
    }
    public async Task AlterarSenhaAsync(string email, string senhaAtual, string novaSenha)
    {
        var cliente = await _clienteRepositorio.ObterPorEmailAsync(email);

        if (cliente == null)
        {
            throw new Exception("Cliente não existe");
        }

        if (senhaAtual != cliente.Senha)
        {
            throw new Exception("Senha Atual Inválida");
        }

        if (novaSenha == cliente.Senha)
        {
            throw new Exception("Senha Inválida");
        }

        cliente.AlterarSenha(novaSenha);
        await _clienteRepositorio.AtualizarAsync(cliente);

    }
    public async Task DeletarAsync(int clienteId)
    {
        var cliente = await _clienteRepositorio.ObterAsync(clienteId);
        if (cliente == null)
        {
            throw new Exception("Cliente não existe");
        }

        if (cliente.Ativo == false)
        {
            throw new Exception("Cliente Inativo");
        }

        cliente.Deletar();
        await _clienteRepositorio.AtualizarAsync(cliente);
    }
    public async Task RestaurarAsync(int clienteId)
    {
        var cliente = await _clienteRepositorio.ObterAsync(clienteId);
        if (cliente.Ativo == true)
        {
            throw new Exception("Cliente Ativo");
        }

        cliente.Restaurar();
        await _clienteRepositorio.AtualizarAsync(cliente);

    }
}