namespace Trabalho.Repositorio;

public abstract class BaseRepositorio
{
    protected readonly TrabalhoContexto _contexto;

    protected BaseRepositorio(TrabalhoContexto contexto)
    {
        _contexto = contexto;
    }
}