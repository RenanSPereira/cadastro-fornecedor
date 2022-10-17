using CadastroFornecedor.Api.Application.Service.Interface;
using CadastroFornecedor.Api.Application.ViewModel;
using CadastroFornecedor.Api.Domain.Interfaces;

namespace CadastroFornecedor.Api.Application.Service;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _repositoryFornecedor;

    public FornecedorService(IFornecedorRepository repositoryFornecedor)
    {
        _repositoryFornecedor = repositoryFornecedor;
    }

    public async Task<FornecedorViewModel> ObterFornecedorPorId(Guid id)
    {
        var fornecedor = await _repositoryFornecedor.ObterPorId(id);
        return FornecedorViewModel.Mapear(fornecedor);
    }

    public void Dispose()
    {
        _repositoryFornecedor?.Dispose();
    }
}
