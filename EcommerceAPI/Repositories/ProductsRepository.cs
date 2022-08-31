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
            try
            {
                var response = await _context.ProductsDatabase.ToListAsync();
                return response;
            }catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Products> PatchProductAsync(ProductsDTO productDTO)
        {
            try {
                int quantityAvailable = await _context.ProductsDatabase.Where(x => x.Title == productDTO.Title).Select(x => x.Available).FirstOrDefaultAsync();
                if (productDTO.Requested > quantityAvailable)
                {
                    return null;
                }
                var products = new Products
                {
                    Id = await _context.ProductsDatabase.Where(x => x.Title == productDTO.Title).Select(x => x.Id).FirstOrDefaultAsync(),
                    Title = await _context.ProductsDatabase.Where(x => x.Title == productDTO.Title).Select(x => x.Title).FirstOrDefaultAsync(),
                    Price = await _context.ProductsDatabase.Where(x => x.Title == productDTO.Title).Select(x => x.Price).FirstOrDefaultAsync(),
                    Available = (quantityAvailable - productDTO.Requested)
                };
                _context.ProductsDatabase.Update(products);
                await _context.SaveChangesAsync();
                return products;
            }
             catch (Exception e)
            {
                return null;
            }
            
        }

        public async Task<Products> PostProductAsync(Products product)
        {
            try
            {
                _context.ProductsDatabase.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
