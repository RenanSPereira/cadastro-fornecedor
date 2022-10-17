using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Enum;
using CadastroFornecedor.Api.Domain.ValueObject;

namespace CadastroFornecedor.Api.Application.ViewModel;

public class FornecedorViewModel
{
    public Guid Id { get; set; }
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; private set; }
    public EnderecoViewModel? Endereco { get; private set; }
    public TipoFornecedor TipoFornecedor { get; private set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public static FornecedorViewModel Mapear(Fornecedor f)
    {
        return new FornecedorViewModel
        {
            Id = f.Id,
            NomeFantasia = f.NomeFantasia,
            RazaoSocial = f.RazaoSocial,
            Cnpj = f.Cnpj.Numero,
            Endereco = EnderecoViewModel.Mapear(f.Endereco),
            TipoFornecedor = f.TipoFornecedor,
            DataCadastro = f.DataCadastro,
            DataAlteracao = f.DataAlteracao
        };
    }
}

public class EnderecoViewModel
{
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Numero { get; set; }

    public static EnderecoViewModel Mapear(Endereco e)
    {
        return new EnderecoViewModel
        {
            Logradouro = e.Logradouro,
            Bairro = e.Bairro,
            Numero = e.Numero
        };
    }
}

