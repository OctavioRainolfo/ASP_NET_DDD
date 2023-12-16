using Microsoft.AspNetCore.Mvc;
using Gerenciador_de_caixa.Data;
using Gerenciador_de_caixa.Models;
using Microsoft.EntityFrameworkCore;
using Gerenciador_de_caixa.Models.Dto;
using AutoMapper;

namespace Gerenciador_de_caixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProdutosController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutoDto produto)
        {
            Produto produtoModel = _mapper.Map<Produto>(produto);
            _context.Produtos.Add(produtoModel);
            await _context.SaveChangesAsync();
            return produtoModel;
        }

        //DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
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

        //PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, ProdutoDto produto)
        {

            if (!await ProdutoExists(id))
            {
                return NotFound();
            }

            Produto produtoModel = _mapper.Map<Produto>(produto);
            produtoModel.Id = id; // Set the ID from the URL
            _context.Entry(produtoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return NoContent();
        }

        //validate if the product exists
        private async Task<bool> ProdutoExists(int id)
        {
            var produtoExiste = await _context.Produtos.FindAsync(id);

            if (produtoExiste == null)
            {
                return false;
            }
            return true;
        }
    }
}
