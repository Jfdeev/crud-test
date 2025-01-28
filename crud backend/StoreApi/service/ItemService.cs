using StoreApi.Models;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(int id);
    Task<Item> AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(int id);
}

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Item >> GetAllAsync()
    {
        return await _itemRepository.GetAllAsync();
    }

    public async Task<Item> GetByIdAsync(int id)
    {
        return await _itemRepository.GetByIdAsync(id);
    }

    public async Task<Item> AddAsync(Item item)
    {
        return await _itemRepository.AddAsync(item);
    }

    public async Task UpdateAsync(Item item)
    {
        await _itemRepository.UpdateAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        await _itemRepository.DeleteAsync(id);
    }
}