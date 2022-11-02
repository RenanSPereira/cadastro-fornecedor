using CadastroFornecedor.Api.Domain.Validation;
using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Test;

public class CnpjValidationTest
{
    [Fact]
    public void Deve_Retornar_False_Para_CNPJ_Invalido()
    {
        Assert.False(new CnpjValidation("121212121").Validar());
    }

    [Fact]
    public void Deve_Retornar_True_Para_CNPJ_Valido()
    {
        Assert.True(new CnpjValidation("38.071.355/0001-44").Validar());
    }
}