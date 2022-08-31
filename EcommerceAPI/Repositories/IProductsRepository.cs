using EcommerceAPI.Models;

namespace EcommerceAPI.Facades
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
        public Task<Products> PatchProductAsync(ProductsDTO productsDTO);
        public Task<Products> PostProductAsync(Products products);
    }
}
