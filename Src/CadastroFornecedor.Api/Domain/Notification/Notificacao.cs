namespace CadastroFornecedor.Api.Domain.Notification;

public class Notificacao
{
    public string Mensagem { get; private set; }

    public Notificacao(string mensagem)
    {
        Mensagem = mensagem;
    }
}
