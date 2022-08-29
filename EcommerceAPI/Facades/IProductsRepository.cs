using EcommerceAPI.Models;

namespace EcommerceAPI.Facades
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetProductsAsync();
    }
}
