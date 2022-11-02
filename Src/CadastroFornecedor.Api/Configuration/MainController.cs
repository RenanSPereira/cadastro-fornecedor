using CadastroFornecedor.Api.Domain.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CadastroFornecedor.Api.Configuration;


[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotification _notificacao;

    protected MainController(INotification notificacao)
    {
        _notificacao = notificacao;
    }

    protected ActionResult CustomResponse(object? resultado = null)
    {
        if (_notificacao.ExisteNotificacao())
        {
            return BadRequest(new
            {
                sucesso = false,
                data = _notificacao.ObterNotificacoes()
            });
        }

        return Ok(new
        {
            sucesso = true,
            data = resultado
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary model)
    {
        if (!model.IsValid)
        {
            var erros = model.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var message = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                _notificacao.AdicionarNotificacao(message);
            }
        }
        return CustomResponse();
    }

    protected void AdicionarErro(string mensagem)
    {
        _notificacao.AdicionarNotificacao(mensagem);
    }
}