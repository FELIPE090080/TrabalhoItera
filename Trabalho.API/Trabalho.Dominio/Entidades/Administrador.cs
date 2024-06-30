using Trabalho.API.Trabalho.Dominio;

public class Administrador : EntidadeBase
{
    private string _nome;
    private string _email;
    private string _senha;

    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Nome Inválido");
            }

            _nome = value;
        }
    }
    public string Senha
    {
        get { return _senha; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Senha Inválida");
            }

            _senha = value;
        }
    }
    public string Email
    {
        get { return _email; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Email Inválido");
            }

            _email = value;
        }
    }

     public Administrador() { }
    public Administrador(string nome, string email, string senha)
    {
        _nome = nome;
        _email = email;
        _senha = senha;
    }


    public void AlterarSenha(string novaSenha)
    {
        Senha = novaSenha;
    }

}