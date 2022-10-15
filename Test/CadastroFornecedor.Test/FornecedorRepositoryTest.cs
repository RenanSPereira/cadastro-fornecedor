using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Enum;
using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Domain.ValueObject;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CadastroFornecedor.Test;

public class FornecedorRepositoryTest
{
    private IRepository<Fornecedor> _repositorio;
    public FornecedorRepositoryTest()
    {
        _repositorio = Substitute.For<IRepository<Fornecedor>>();
    }

    [Fact]
    public async Task Deve_Retornar_Nulo_Caso_Fornecedor_Nao_Seja_Econtrado()
    {
        _repositorio.ObterPorId(Arg.Any<Guid>()).ReturnsNull<Fornecedor>();

        var fornecedor = await _repositorio.ObterPorId(Guid.NewGuid());

        Assert.Null(fornecedor);
    }

    [Fact]
    public async Task Deve_Retornar_Um_Fornecedor_Caso_Ele_Exista()
    {
        //contexto
        var fornecedor = new Fornecedor("Nome Fantasia Teste", "Razao Social Teste",
            new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
            TipoFornecedor.NaoPereciveis);

        _repositorio.ObterPorId(fornecedor.Id).Returns(fornecedor);

        //Ação
        var resultado = await _repositorio.ObterPorId(fornecedor.Id);

        //Verificação
        Assert.Equal(resultado.Id, fornecedor.Id);
    }

    [Fact]
    public async Task Deve_Remover_O_Fornecedor()
    {
        //contexto
        var fornecedor = new Fornecedor("Nome Fantasia Teste", "Razao Social Teste",
            new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
            TipoFornecedor.NaoPereciveis);

        _repositorio
            .When(x => x.Remover(fornecedor))
            .Do(x => _repositorio.ObterPorId(fornecedor.Id).ReturnsNull());

        //Ação
        await _repositorio.Remover(fornecedor);
        var resultado = await _repositorio.ObterPorId(fornecedor.Id);

        //Verificação
        Assert.Null(resultado);
    }


    [Fact]
    public async Task Deve_Trazer_Todos_Os_Fornecedores_Cadastrados()
    {
        //contexto
        var fornecedores = new List<Fornecedor>()
        {
            new Fornecedor("Nome Fantasia Teste", "Razao Social Teste",
                new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
                TipoFornecedor.NaoPereciveis),

            new Fornecedor("Nome Fantasia Teste", "Razao Social Teste",
                new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
                TipoFornecedor.NaoPereciveis),

            new Fornecedor("Nome Fantasia Teste", "Razao Social Teste",
                new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
                TipoFornecedor.NaoPereciveis)
        };

        _repositorio.ObterTodos().Returns(fornecedores);

        //Ação
        var resultado = await _repositorio.ObterTodos();

        //Verificação
        Assert.Equal(3, fornecedores.Count);
    }
}