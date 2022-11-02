using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Test;

public class CnpjValidationTest
{
    [Fact]
    public void Deve_Lancar_Exception_Para_Cnpj_Invalido()
    {
        var exception = Assert.Throws<ArgumentException>(() => new Cnpj("12121"));
        Assert.Equal("Cnpj inválido", exception.Message);
    }

    [Fact]
    public void Deve_Criar_Cnpj_Com_Numero_Valido()
    {
        var cnpj = new Cnpj("38.071.355/0001-44");
        Assert.Equal("38.071.355/0001-44", cnpj.Numero);
    }
}