﻿using EcommerceAPI.Data;
using EcommerceAPI.Facades;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories.Users;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var response = await _repository.GetProductsAsync();
            return response is not null ? Ok(response) : NotFound("Nenhum produto encontrado");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _repository.GetProductByIdAsync(id);
            return response is not null ? Ok(response) : NotFound("Produto não encontrado");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProduct([FromBody] Products products)
        {
            var response = await _repository.PostProductAsync(products);
            return response is not null ? Ok(response) : BadRequest("Não foi posivel adicionar o produto");
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductsDTO productsDTO)
        {
            var response = await _repository.PatchProductAsync(id, productsDTO);
            return response is not null ? Ok(response) : BadRequest("Não foi posivel editar o produto");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _repository.DeleteProductAsync(id);
            return response is not null ? Ok() : BadRequest("Não foi posivel deletar o produto");
        }
    }
}
