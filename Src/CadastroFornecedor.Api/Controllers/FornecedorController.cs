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

    [HttpGet("{id:guid}")]
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

    [HttpPost]
    public async Task<ActionResult<Guid>> CadastrarFornecedor(FornecedorModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var resultado = await _fornecedorService.CadastrarFornecedor(model);
        return CustomResponse(resultado);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<string>> RemoverFornecedor(Guid id)
    {
        var resultado = await _fornecedorService.RemoverFornecedor(id);

        if (resultado.Key == -1) return BadRequest(resultado.Value);

        return Ok(resultado.Value);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
    {
        var fornecedores = await _fornecedorRepository.ObterTodos();

        if (fornecedores.Count() == 0)
        {
            AdicionarErro("Não há fornecedor cadastrado");
        } 

        var fornecedoresViewModel = fornecedores.Select(FornecedorViewModel.Mapear).ToList();

        return CustomResponse(fornecedoresViewModel);
    }
}
