namespace CadastroFornecedor.Api.Domain.Notification;

public interface INotification
{
    bool ExisteNotificacao();
    void AdicionarNotificacao(string notificacao);
}
