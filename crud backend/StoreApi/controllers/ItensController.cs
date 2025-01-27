using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ItemController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item >>> GetItems()
    {
        return await _context.Items.Include(i => i.Product).ToListAsync();
    }

    [HttpGet("(id)")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _context.Items.Include(i => i.Product).FirstOrDefaultAsync(i => i.Id == id);
        if(item == null)
        {
            return NotFound();
        }
        return item;
    }
}