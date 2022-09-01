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
        [HttpPost]
        public async Task<IActionResult> AddProducts(Products products)
        {
            var response = await _repository.PostProductAsync(products);
            return response is not null ? Ok(response) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditProducts(ProductsDTO productsDTO)
        {
            var response = await _repository.PutProductAsync(productsDTO);
            return response is not null ? Ok(response) : BadRequest();
        }
    }
}
