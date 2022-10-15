namespace CadastroFornecedor.Api.Domain.Interfaces;

public interface IRepository<EntityBase>
{
    EntityBase ObterPorId(Guid id);
    void Adicionar(EntityBase entity);
    void Atualizar(EntityBase entity);
    void Remover(EntityBase entity);
}
