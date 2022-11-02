using CadastroFornecedor.Api.Application.Model;
using CadastroFornecedor.Api.Application.ViewModel;

namespace CadastroFornecedor.Api.Domain.Service.Interface;

public interface IFornecedorService : IDisposable
{
    Task<Guid> CadastrarFornecedor(FornecedorModel fornecedor);
    Task<Guid> RemoverFornecedor(Guid id);
}
