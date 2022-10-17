using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Application.Service.Interface;
using CadastroFornecedor.Api.Application.ViewModel;
using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Domain.ValueObject;

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

        if (fornecedor is null) return null;

        return FornecedorViewModel.Mapear(fornecedor);
    }

    public async Task<Guid> CadastrarFornecedor(FornecedorModel fornecedor)
    {
        var endereco = new Endereco(fornecedor.Logradouro, fornecedor.Bairro, fornecedor.Numero);

        var novoFornecedor = new Fornecedor(fornecedor.NomeFantasia, fornecedor.RazaoSocial,
        new Cnpj(fornecedor.Cnpj), endereco, fornecedor.TipoFornecedor);

        await _repositoryFornecedor.Adicionar(novoFornecedor);

        return novoFornecedor.Id;
    }

    public void Dispose()
    {
        _repositoryFornecedor?.Dispose();
    }
}
