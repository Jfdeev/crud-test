using Microsoft.AspNetCore.Mvc;
using StoreApi.Models; 

[ApiController]
[Route("api/(controller)")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllAsync()
    {
        var items = await _itemService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetByIdAsync(int id)
    {
        var item = await _itemService.GetByIdAsync(id);
        if(item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> AddAsync(Item item)
    {
        var createItem = await _itemService.AddAsync(item);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createItem.Id }, createItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, Item item)
    {
        if(id != item.Id)
        {
            return BadRequest();
        }
        await _itemService.UpdateAsync(item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var exists = await _itemService.GetByIdAsync(id);
        if(exists == null)
        {
            return NotFound();
        }

        await _itemService.DeleteAsync(id);
        return NoContent();
    }
}