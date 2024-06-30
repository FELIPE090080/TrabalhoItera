public interface IAdministradorAplicacao
{
    Task AtualizarAsync(Administrador administrador);
    Task<int> CriarAsync(Administrador administrador);
    Task<Administrador> ObterAsync(int administradorId);
    Task<int> LogarAsync(string email, string senha);


}