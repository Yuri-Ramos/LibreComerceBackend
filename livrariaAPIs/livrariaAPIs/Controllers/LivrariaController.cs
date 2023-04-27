using livraria.Models;
using livrariaAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace livraria.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context)
        {
            _context = context;
            _context.ToDoProducts.Add(new Produto { Id = 1,
                Nome = "Book1",
                Preco = 15,
                quantidade = 1,
                categoria = "Action",
                Img = "img1" });

            _context.ToDoProducts.Add(new Produto
            {
                Id = 1,
                Nome = "Book1",
                Preco = 15,
                quantidade = 1,
                categoria = "Action",
                Img = "img1"
            });
            _context.ToDoProducts.Add(new Produto
            {
                Id = 1,
                Nome = "Book1",
                Preco = 15,
                quantidade = 1,
                categoria = "Action",
                Img = "img1"
            });
            _context.ToDoProducts.Add(new Produto
            {
                Id = 2,
                Nome = "Book2",
                Preco = 15,
                quantidade = 1,
                categoria = "Action",
                Img = "img1"
            });
            _context.ToDoProducts.Add(new Produto
            {
                Id = 3,
                Nome = "Book3",
                Preco = 15,
                quantidade = 1,
                categoria = "Action",
                Img = "img1"
            });
            _context.SaveChanges();
        }
        [HttsGet]
        public async Task<ActionResult<Enumerable<Produto>>> GetProdutos()
        {
            return await _context.ToDoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.ToDoProducts.FindAsync(id.ToString());

            if(item== null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async  Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.ToDoProducts.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, product)
        }

        // GET: api/bookstore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var todoItem = await _context.TodoProducts.FindAsync(id.ToString());

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

    }
}
