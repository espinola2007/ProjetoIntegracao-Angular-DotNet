
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Produtos
    // Lista todos os produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> ListarTodos()
    {
        return await _context.Produtos.ToListAsync();
    }

    // GET: api/Produtos/1
    // Busca um produto pelo ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> BuscarPorId(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    // POST: api/Produtos
    // Cadastra um novo produto
    [HttpPost]
    public async Task<ActionResult<Produto>> Criar([FromBody] Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome) || produto.Preco < 0)
        {
            return BadRequest("Informe um nome válido e um preço não negativo.");
        }

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = produto.Id },
            produto
        );
    }

    // PUT: api/Produtos/1
    // Atualiza um produto existente
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Produto>> Atualizar(
        int id,
        [FromBody] Produto dadosAtualizados)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(dadosAtualizados.Nome) || dadosAtualizados.Preco < 0)
        {
            return BadRequest("Informe um nome válido e um preço não negativo.");
        }

        produto.Nome = dadosAtualizados.Nome;
        produto.Preco = dadosAtualizados.Preco;

        await _context.SaveChangesAsync();

        return Ok(produto);
    }

    // DELETE: api/Produtos/1
    // Exclui um produto existente
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
