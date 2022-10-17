using CadastroFornecedor.Api.Application.ViewModel;

namespace CadastroFornecedor.Api.Application.Service.Interface;

public interface IFornecedorService : IDisposable
{
    Task<FornecedorViewModel> ObterFornecedorPorId(Guid id);
}
