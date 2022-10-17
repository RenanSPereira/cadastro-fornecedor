using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Enum;

namespace CadastroFornecedor.Api.Application.ViewModel;

public class FornecedorViewModel
{
    public Guid Id { get; set; }
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; private set; }
    public string? Endereco { get; private set; }
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
            Endereco = f.Endereco.Logradouro,
            TipoFornecedor = f.TipoFornecedor,
            DataCadastro = f.DataCadastro,
            DataAlteracao = f.DataAlteracao
        };
    }
}



