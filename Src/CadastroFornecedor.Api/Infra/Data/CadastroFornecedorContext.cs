using CadastroFornecedor.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using CadastroFornecedor.Api.Infra.Configuration;

namespace CadastroFornecedor.Api.Infra.Data;

public class CadastroFornecedorContext : DbContext
{
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public CadastroFornecedorContext(DbContextOptions<CadastroFornecedorContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new FornecedorMap());
    }
}
