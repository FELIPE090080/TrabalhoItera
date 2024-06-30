using Trabalho.API.Repositorio;
namespace Trabalho.Aplicacao;

public class AdministradorAplicacao : IAdministradorAplicacao
{

    private readonly IAdministradorRepositorio _administradorRepositorio;

    public AdministradorAplicacao(AdministradorRepositorio administradorRepositorio)
    {
        _administradorRepositorio = administradorRepositorio;

    }
    public async Task AtualizarAsync(Administrador administrador)
    {
        var administradorDominio = await _administradorRepositorio.ObterAsync(administrador.Id);

        if (administradorDominio == null)
        {
            throw new Exception("Administrador Inválido");
        }

        administradorDominio = administrador;

        await _administradorRepositorio.AtualizarAsync(administradorDominio);

    }
    public async Task<int> CriarAsync(Administrador administrador)
    {
        if (administrador == null)
        {
            throw new Exception("Administrador não pode ser Vazio");
        }

        var administradorDominio = await _administradorRepositorio.ObterPorEmailAsync(administrador.Email);

        if (administradorDominio != null)
        {
            throw new Exception("Email Inválido");
        }

        var administradorId = await _administradorRepositorio.CriarAsync(administrador);

        return administradorId;
    }

    public async Task<int> LogarAsync(string email, string senha)
    {

        if (email == null)
        {
            throw new Exception("Email e/ou Senha inválidos");
        }

        var administradorDominio = await _administradorRepositorio.ObterPorEmailAsync(email);

        if (administradorDominio.Senha != senha)
        {
            throw new Exception("Email e/ou Senha inválidos");
        }

        return administradorDominio.Id;
    }

    public async Task<Administrador> ObterAsync(int administradorId)
    {
        var administrador = await _administradorRepositorio.ObterAsync(administradorId);
        if (administrador == null)
        {
            throw new Exception("Administrador não existe");
        }
        return administrador;
    }
}