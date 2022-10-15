namespace CadastroFornecedor.Api.Domain.ValueObject;

public record Cnpj
{
    public string Numero { get; private set; }

    public Cnpj(string numero)
    {
        Numero = numero;
    }
}
