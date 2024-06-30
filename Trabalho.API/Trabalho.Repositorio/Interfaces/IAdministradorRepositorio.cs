public interface IAdministradorRepositorio
{
    Task<int> CriarAsync(Administrador administrador);
    Task AtualizarAsync(Administrador administrador); 
    Task<Administrador> ObterAsync(int administradorId);
    Task<Administrador> ObterPorEmailAsync(string email);
}