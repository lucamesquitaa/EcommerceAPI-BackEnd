using EcommerceAPI.Models;

namespace EcommerceAPI.Facades
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
        public Task<Products> GetProductByIdAsync(int id);
        public Task<Products> PutProductAsync(ProductsDTO productsDTO);
        public Task<Products> PostProductAsync(Products products);
        public Task<bool> DeleteProductAsync(int id);
    }
}
