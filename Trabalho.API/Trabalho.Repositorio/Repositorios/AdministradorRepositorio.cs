using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Trabalho.API.Repositorio;
using Trabalho.Repositorio;

public class AdministradorRepositorio : BaseRepositorio, IAdministradorRepositorio
{
    public AdministradorRepositorio(TrabalhoContexto contexto) : base(contexto) { }

    public async Task AtualizarAsync(Administrador administrador)
    {
        _contexto.Update(administrador);
        await _contexto.SaveChangesAsync();
    }

    public async Task<int> CriarAsync(Administrador administrador)
    {
        await _contexto.Administradores.AddAsync(administrador);
        await _contexto.SaveChangesAsync();
        return administrador.Id;
    }

    public async Task<Administrador> ObterAsync(int administradorId)
    {
        return await _contexto.Administradores
                                    .Where(administrador => administrador.Id == administradorId)
                                    .FirstOrDefaultAsync();
    }

    public async Task<Administrador> ObterPorEmailAsync(string email)
    {
        var administrador = await _contexto.Administradores
                                    .Where(administrador => administrador.Email == email)
                                    .FirstOrDefaultAsync();

        return administrador;
    }
}