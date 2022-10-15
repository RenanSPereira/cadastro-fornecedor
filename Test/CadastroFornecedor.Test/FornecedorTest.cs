using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Enum;
using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Test;

public class FornecedorTest
{
    private Fornecedor _fornecedor;

    public FornecedorTest()
    {
        _fornecedor = new Fornecedor("Nome Fantasia Teste", "Razao Social Teste", 
        new Cnpj("38.071.355/0001-44"), new Endereco("Logradouro Teste", "Bairro Teste", "520C"),
        TipoFornecedor.NaoPereciveis);
    }

    [Fact]
    public void Deve_Gerar_Um_Id_Valido_Para_Um_Novo_Fornecedor()
    {
        Assert.NotStrictEqual<Guid>(Guid.Empty, _fornecedor.Id);
    }
}
