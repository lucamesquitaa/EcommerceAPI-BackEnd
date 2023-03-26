using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Repositories
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
        public Task<Products> GetProductByIdAsync(int id);
        public Task<Products> PatchProductAsync(int id, int requested);
        public Task<Products> PostProductAsync([FromBody] Products products);
        public Task<Products> DeleteProductAsync(int id);
    }
}
