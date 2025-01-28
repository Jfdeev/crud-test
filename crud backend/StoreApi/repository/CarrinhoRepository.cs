using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;

public interface ICarrinhoRepository
{
    Task<IEnumerable<Carrinho>> GetAllAsync();
    Task<Carrinho> GetByIdAsync(int id);
    Task<Carrinho> AddAsync(Carrinho carrinho);
    Task UpdateAsync(Carrinho carrinho);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly AppDbContext _context;

    public CarrinhoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Carrinho>> GetAllAsync()
    {
        return await _context.Carrinhos.Include(c => c.ItensCarrinho).ToListAsync();
    }

    public async Task<Carrinho> GetByIdAsync(int id)
    {
        return await _context.Carrinhos.Include(c => c.ItensCarrinho).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Carrinho> AddAsync(Carrinho carrinho)
    {
        _context.Carrinhos.Add(carrinho);
        await _context.SaveChangesAsync();
        return carrinho;
    }

    public async Task UpdateAsync(Carrinho carrinho)
    {
        _context.Entry(carrinho).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var carrinho = await GetByIdAsync(id);
        if(carrinho != null)
        {
            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Carrinhos.AnyAsync(e => e.Id == id);
    }
}