using Microsoft.AspNetCore.Mvc;
using u21497682_HW01_API.Models;
using u21497682_HW01_API.Repositories;

namespace u21497682_HW01_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var newProduct = await _productRepository.AddProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Product_ID }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Product_ID)
            {
                return BadRequest();
            }

            var updatedProduct = await _productRepository.UpdateProduct(product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProduct(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
