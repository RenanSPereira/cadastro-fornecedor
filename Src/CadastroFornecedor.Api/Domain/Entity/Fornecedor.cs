using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Api.Domain.Entity;

public class Fornecedor : EntityBase
{
    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public Cnpj Cnpj { get; private set; }
    public Endereco Endereco {get; private set;}

    public Fornecedor(string nomeFantasia, string razaoSocial, Cnpj cnpj, Endereco endereco)
    {
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        Endereco = endereco;
    }
}
