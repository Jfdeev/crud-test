using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;

public interface ICarrinhoService
{
    Task<IEnumerable<Carrinho>> GetAllAsync();
    Task<Carrinho> GetByIdAsync(int id);
    Task<Carrinho> AddAsync(Carrinho carrinho);
    Task UpdateAsync(Carrinho carrinho);
    Task DeleteAsync(int id);
}

public class CarrinhoService : ICarrinhoService
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public CarrinhoService(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<IEnumerable<Carrinho>> GetAllAsync()
    {
        return await _carrinhoRepository.GetAllAsync();
    }

    public async Task<Carrinho> GetByIdAsync(int id)
    {
        return await _carrinhoRepository.GetByIdAsync(id);
    }

    public async Task<Carrinho> AddAsync(Carrinho carrinho)
    {
        return await _carrinhoRepository.AddAsync(carrinho);
    }

    public async Task UpdateAsync(Carrinho carrinho)
    {
        await _carrinhoRepository.UpdateAsync(carrinho);
    }

    public async Task DeleteAsync(int id)
    {
        await _carrinhoRepository.DeleteAsync(id);
    }
}