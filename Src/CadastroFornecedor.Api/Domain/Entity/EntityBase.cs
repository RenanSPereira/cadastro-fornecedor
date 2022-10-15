namespace CadastroFornecedor.Api.Domain.Entity;

public abstract class EntityBase
{
    public Guid Id { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public bool Excluido { get; private set; }

    public void MarcarComoExcluido() => Excluido = true;
}
