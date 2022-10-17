using CadastroFornecedor.Api.Domain.Entity;
using CadastroFornecedor.Api.Domain.Interfaces;
using CadastroFornecedor.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroFornecedor.Api.Infra.Repository;

public class FornecedorRepository : IRepository<Fornecedor>
{
    private readonly CadastroFornecedorContext _context;

    public FornecedorRepository(CadastroFornecedorContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Fornecedor entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Fornecedor entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Fornecedor?> ObterPorId(Guid id)
    {
        return await _context.Fornecedores.FindAsync(id);
    }

    public async Task<IEnumerable<Fornecedor>> ObterTodos()
    {
        return await _context.Fornecedores.Where(x => !x.Excluido).ToListAsync();
    }

    public async Task Remover(Fornecedor entity)
    {
        entity.MarcarComoExcluido();
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}