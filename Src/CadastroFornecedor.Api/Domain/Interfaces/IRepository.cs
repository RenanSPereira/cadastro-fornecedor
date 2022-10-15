namespace CadastroFornecedor.Api.Domain.Interfaces;

public interface IRepository<EntityBase>
{
    Task<EntityBase> ObterPorId(Guid id);
    Task Adicionar(EntityBase entity);
    Task Atualizar(EntityBase entity);
    Task Remover(EntityBase entity);
}
