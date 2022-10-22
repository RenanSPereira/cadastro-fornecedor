using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Api.Domain.Service.Interface;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _repositoryFornecedor;

    public FornecedorService(IFornecedorRepository repositoryFornecedor)
    {
        _repositoryFornecedor = repositoryFornecedor;
    }

    public async Task<Guid> CadastrarFornecedor(FornecedorModel fornecedor)
    {
        var endereco = new Endereco(fornecedor.Logradouro, fornecedor.Bairro, fornecedor.Numero);

        var novoFornecedor = new Fornecedor(fornecedor.NomeFantasia, fornecedor.RazaoSocial,
        new Cnpj(fornecedor.Cnpj), endereco, fornecedor.TipoFornecedor);

        await _repositoryFornecedor.Adicionar(novoFornecedor);

        return novoFornecedor.Id;
    }

    public async Task<KeyValuePair<int, string>> RemoverFornecedor(Guid id)
    {
        var fornecedor = await _repositoryFornecedor.ObterPorId(id);

        if (fornecedor is null)
        {
            return new KeyValuePair<int, string>(-1, "Fornecedor Não Encontrado");
        }

        await _repositoryFornecedor.Remover(fornecedor);

        return new KeyValuePair<int, string>(0, "Fornecedor removido");
    }


    public void Dispose()
    {
        _repositoryFornecedor?.Dispose();
    }
}