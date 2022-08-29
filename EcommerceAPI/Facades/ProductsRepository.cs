using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Facades
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApiContext _context;
        public ProductsRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            var response = await _context.ProductsDb.ToListAsync();
            return response;
        }
    }
}
