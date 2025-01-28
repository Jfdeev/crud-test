using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;


public interface IItemRepository
{
    Task<IEnumerable<Item >> GetAllAsync();
    Task<Item> GetByIdAsync(int id);
    Task<Item> AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _context.Items.Include(i => i.Product).ToListAsync();
    }

    public async Task<Item> GetByIdAsync(int id)
    {
        return await _context.Items.Include(i => i.Product).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Item> AddAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if(item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Items.AnyAsync(e => e.Id == id);
    }
}