using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Services;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<Product>> GetList()
        {
            var products = await _service.GetListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var existingProduct = await _service.GetAsync(product.Id);
            if (existingProduct != null) return Conflict();


            var result = await _service.CreateAsync(product);
            if (result == null) return BadRequest();
            return Created(product.Id, result);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            var existingProduct = await _service.GetAsync(product.Id);
            if (existingProduct == null) return NotFound();


            var result = await _service.UpdateAsync(product);
            if (result == null) return BadRequest();
            return Ok(product);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            var existingProduct = await _service.GetAsync(id);
            if (existingProduct == null) return NotFound();


            var result = await _service.DeleteAsync(id);
            if (result == 0) return BadRequest();
            return Accepted(result);
        }
    }
}