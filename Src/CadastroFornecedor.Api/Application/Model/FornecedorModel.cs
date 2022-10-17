using CadastroFornecedor.Api.Domain.Enum;

namespace CadastroFornecedor.Api.Application.Model;

public class FornecedorModel
{
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Numero { get; set; }
    public TipoFornecedor TipoFornecedor { get; set; }
}
