using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models; // Assuming Carrinho is defined in the Models namespace

[ApiController]
[Route("api/[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly ICarrinhoService _carrinhoService;

    public CarrinhoController(ICarrinhoService carrinhoService)
    {
        _carrinhoService = carrinhoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carrinho>>> GetAllAsync()
    {
        var carrinhos = await _carrinhoService.GetAllAsync();
        return Ok(carrinhos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Carrinho>> GetByIdAsync(int id)
    {
        var carrinho = await _carrinhoService.GetByIdAsync(id);
        if(carrinho == null)
        {
            return NotFound();
        }
        return Ok(carrinho);
    }

    [HttpPost]
    public async Task<ActionResult<Carrinho>> AddAsync(Carrinho carrinho)
    {
        var createCarrinho = await _carrinhoService.AddAsync(carrinho);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createCarrinho.Id }, createCarrinho);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarrinho(int id, Carrinho carrinho)
    {
        if(id != carrinho.Id)
        {
            return BadRequest();
        }
        await _carrinhoService.UpdateAsync(carrinho);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarrinho(int id)
    {
        var exists = await _carrinhoService.GetByIdAsync(id);
        if(exists == null)
        {
            return NotFound();
        }

        await _carrinhoService.DeleteAsync(id);
        return NoContent();
    }
}