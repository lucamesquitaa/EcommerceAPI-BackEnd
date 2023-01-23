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
                var response = await _context.ContextProductsAPI.AsNoTracking().ToListAsync();
                if (response == null)
                {
                    throw new Exception("Was not found products");
                }
                return response;
            }catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<Products> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _context.ContextProductsAPI.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (response == null)
                {
                    throw new Exception("Was not found a matching id");
                }
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Products> PutProductAsync(int id, ProductsDTO productDTO)
        {
            try {
                Products produto = await _context.ContextProductsAPI.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
        ;
                if (produto == null || produto.Id <= 0)
                {
                    throw new Exception("Was not found a matching id");
                }

                if (productDTO.Requested > produto.Available)
                {
                    throw new Exception("The quantity requested is bigger than quantity available");
                }
                
                var newProduct = new Products
                {
                    Id = produto.Id,
                    Title = produto.Title,
                    Photo = produto.Photo,
                    Category = produto.Category,
                    Price = produto.Price,
                    Available = (produto.Available - productDTO.Requested)
                };

                _context.ContextProductsAPI.Update(newProduct);
                await _context.SaveChangesAsync();
                return newProduct;
            }
             catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public async Task<Products> PostProductAsync(Products product)
        {
            try
            {
                _context.ContextProductsAPI.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _context.ContextProductsAPI.FindAsync(id);
                if (response == null)
                {
                    throw new Exception("Was not found a matching id");
                }
                _context.ContextProductsAPI.Remove(response);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
