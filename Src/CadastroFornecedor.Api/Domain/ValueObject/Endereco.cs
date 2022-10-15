namespace CadastroFornecedor.Api.Domain.ValueObject;

public record Endereco
{
    public string Logradouro { get; private set; }
    public string Bairro { get; private set; }
    public string Numero { get; private set; }

    public Endereco(string logradouro, string bairro, string numero)
    {
        Logradouro = logradouro;
        Bairro = bairro;
        Numero = numero;
    }
}
