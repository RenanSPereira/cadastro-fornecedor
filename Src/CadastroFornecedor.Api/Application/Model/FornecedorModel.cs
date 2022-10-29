using System.ComponentModel.DataAnnotations;
using CadastroFornecedor.Api.Domain.Enum;

namespace CadastroFornecedor.Api.Application.Model;

public class FornecedorModel
{
    [Required(ErrorMessage = "Nome Fantasia Deve Ser Informado")]
    public string? NomeFantasia { get; set; }
    [Required(ErrorMessage = "A Razão socia deve ser informada")]
    public string? RazaoSocial { get; set; }
    [Required(ErrorMessage = "O Cnpj deve ser informado")]
    public string? Cnpj { get; set; }
    [Required(ErrorMessage = "O Logradouro deve ser informado")]
    public string? Logradouro { get; set; }
    [Required(ErrorMessage = "O Bairro deve ser informado")]
    public string? Bairro { get; set; }
    [Required(ErrorMessage = "O Número deve ser informado")]
    public string? Numero { get; set; }
    [Required(ErrorMessage = "O tipo dor fornecedor deve ser informado")]
    public TipoFornecedor TipoFornecedor { get; set; }
}
