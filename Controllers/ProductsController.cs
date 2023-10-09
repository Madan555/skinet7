
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Products>>> GetProducts(){
            return await _context.Products.OrderByDescending(o=>o.Id).ToListAsync();
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<Products>> GetProductById(int id){
            return await _context.Products.FindAsync(id);
        }
    }
}