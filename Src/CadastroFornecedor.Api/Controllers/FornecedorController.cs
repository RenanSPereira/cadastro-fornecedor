using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Application.Service.Interface;
using CadastroFornecedor.Api.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFornecedor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorService _fornecedorService;

    public FornecedorController(IFornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpGet("obter-por-id/{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterFornecedorPorId(Guid id)
    {
        var fornecedor = await _fornecedorService.ObterFornecedorPorId(id);

        if (fornecedor is null) return BadRequest();

        return Ok(fornecedor);
    }

    [HttpPost("cadastrar")]
    public async Task<ActionResult<Guid>> CadastrarFornecedor(FornecedorModel model)
    {
        try
        {
            var resultado = await _fornecedorService.CadastrarFornecedor(model);
            return Ok(resultado);
        }
        catch (ArgumentException e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpDelete("remover/{id:guid}")]
    public async Task<ActionResult<string>> RemoverFornecedor(Guid id)
    {
        var resultado = await _fornecedorService.RemoverFornecedor(id);

        if (resultado.Key == -1) return BadRequest(resultado.Value);

        return Ok(resultado.Value);
    }
}
