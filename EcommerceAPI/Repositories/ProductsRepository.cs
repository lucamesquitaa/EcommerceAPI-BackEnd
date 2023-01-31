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
            var response = await _context.ContextProductsAPI.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            var response = await _context.ContextProductsAPI.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<Products> PatchProductAsync(int id, ProductsDTO productDTO)
        {
            Products? produto = await _context.ContextProductsAPI.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
       
            if (productDTO.Requested > produto.Available)
            {
                return null;
            }

            produto.Available = produto.Available - productDTO.Requested;
            
            _context.ContextProductsAPI.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        
        public async Task<Products> PostProductAsync(Products product)
        {
            _context.ContextProductsAPI.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> DeleteProductAsync(int id)
        {
            var response = await _context.ContextProductsAPI.FindAsync(id);

            _context.ContextProductsAPI.Remove(response);
            await _context.SaveChangesAsync();
            return response;
        }
    }
}
