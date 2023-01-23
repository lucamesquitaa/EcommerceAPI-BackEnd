using EcommerceAPI.Data;
using EcommerceAPI.Facades;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _repository.GetProductsAsync();
            return response is not null ? Ok(response) : BadRequest();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _repository.GetProductByIdAsync(id);
            return response is not null ? Ok(response) : BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Products products)
        {
            var response = await _repository.PostProductAsync(products);
            return response is not null ? Ok(response) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductsDTO productsDTO)
        {
            var response = await _repository.PutProductAsync(id, productsDTO);
            return response is not null ? Ok(response) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _repository.DeleteProductAsync(id);
            return response == true ? Ok() : BadRequest();
        }
    }
}
