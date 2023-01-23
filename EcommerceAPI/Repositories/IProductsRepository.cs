using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Facades
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
        public Task<Products> GetProductByIdAsync(int id);
        public Task<Products> PutProductAsync(int id, [FromBody] ProductsDTO productsDTO);
        public Task<Products> PostProductAsync([FromBody] Products products);
        public Task<bool> DeleteProductAsync(int id);
    }
}
