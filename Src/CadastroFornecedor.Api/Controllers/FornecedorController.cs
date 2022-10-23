using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Application.ViewModel;
using CadastroFornecedor.Api.Configuration;
using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFornecedor.Api.Controllers;

[Route("api/fornecedor")]
public class FornecedorController : MainController
{
    private readonly IFornecedorService _fornecedorService;
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorController(IFornecedorService fornecedorService, IFornecedorRepository fornecedorRepository)
    {
        _fornecedorService = fornecedorService;
        _fornecedorRepository = fornecedorRepository;
    }

    [HttpGet("obter-por-id/{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterFornecedorPorId(Guid id)
    {
        var fornecedor = await _fornecedorRepository.ObterPorId(id);

        if (fornecedor is null) 
        {
            AdicionarErro("Fornecedor não encontrado");
            return CustomResponse();
        }

        var fornecedorViewModel = FornecedorViewModel.Mapear(fornecedor);

        return CustomResponse(fornecedor);
    }

    [HttpPost("cadastrar")]
    public async Task<ActionResult<Guid>> CadastrarFornecedor(FornecedorModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var resultado = await _fornecedorService.CadastrarFornecedor(model);
        return CustomResponse(resultado);
    }

    [HttpDelete("remover/{id:guid}")]
    public async Task<ActionResult<string>> RemoverFornecedor(Guid id)
    {
        var resultado = await _fornecedorService.RemoverFornecedor(id);

        if (resultado.Key == -1) return BadRequest(resultado.Value);

        return Ok(resultado.Value);
    }

    [HttpGet("obter-todos")]
    public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
    {
        var resultado = await _fornecedorRepository.ObterTodos();
        return Ok(resultado);
    }
}
