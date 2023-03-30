using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Repositories
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
        public Task<Products> GetProductByIdAsync(int id);
        public Task<Products> PutProductAsync(int id, int requested);
        public Task<Products> PostProductAsync(Products products);
        public Task<Products> DeleteProductAsync(int id);
    }
}
