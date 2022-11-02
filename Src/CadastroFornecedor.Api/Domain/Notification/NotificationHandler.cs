namespace CadastroFornecedor.Api.Domain.Notification;

public class NotificationHandler : INotification
{
    private List<Notificacao> _notificacoes;

    public NotificationHandler()
    {
        _notificacoes = new List<Notificacao>();
    }

    public bool ExisteNotificacao()
    {
        return _notificacoes.Any();
    }

    public void AdicionarNotificacao(string notificacao)
    {
        _notificacoes.Add(new Notificacao(notificacao));
    }

    public IReadOnlyCollection<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }
}
