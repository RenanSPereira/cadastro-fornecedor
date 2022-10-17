using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Application.ViewModel;

namespace CadastroFornecedor.Api.Application.Service.Interface;

public interface IFornecedorService : IDisposable
{
    Task<FornecedorViewModel> ObterFornecedorPorId(Guid id);
    Task<Guid> CadastrarFornecedor(FornecedorModel fornecedor);
    Task<KeyValuePair<int, string>> RemoverFornecedor(Guid id);
}
