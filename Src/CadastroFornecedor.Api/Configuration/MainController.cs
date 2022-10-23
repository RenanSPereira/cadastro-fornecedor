using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CadastroFornecedor.Api.Configuration;


[ApiController]
public abstract class MainController : ControllerBase
{
    private List<string> _erros = new List<string>();
    
    protected ActionResult CustomResponse(object? resultado = null)
    {
        if (PossuiErros())
        {
            return BadRequest(new
            {
                sucesso = false,
                data = _erros.Select(x => x)
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
                _erros.Add(message);
            }
        }
        return CustomResponse();
    }

    private bool PossuiErros()
    {
        return _erros.Any();
    }
}