using EcommerceAPI.Data;
using EcommerceAPI.Facades;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var products = await _repository.GetProductsAsync();
            var productsList = new List<ProductsDTO>();
            try
            {
                foreach (var product in products)
                {
                    var productsDTO = new ProductsDTO
                    {
                        Title = product.Title,
                        Price = product.Price,
                        Requested = product.Requested
                    };
                    productsList.Add(productsDTO);
                }
                return productsList.Any() ? Ok(productsList) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
