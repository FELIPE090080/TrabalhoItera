namespace Trabalho.API;

public class ClienteLogado
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Lote> Lotes { get; set; }
}
