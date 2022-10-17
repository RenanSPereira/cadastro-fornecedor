using CadastroFornecedor.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroFornecedor.Api.Infra.Configuration;

public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedor");
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.Endereco);
        builder.OwnsOne(x => x.Cnpj);
    }
}
