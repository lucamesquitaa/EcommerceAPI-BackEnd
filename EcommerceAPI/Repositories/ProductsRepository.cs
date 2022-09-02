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
                var response = await _context.ProductsEcommerceDB.ToListAsync();
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
                var response = await _context.ProductsEcommerceDB.FindAsync(id);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Products> PutProductAsync(ProductsDTO productDTO)
        {
            try {
                int quantityAvailable = await _context.ProductsEcommerceDB.Where(x => x.Id == productDTO.Id).Select(x => x.Available).FirstOrDefaultAsync();
                if (productDTO.Requested > quantityAvailable)
                {
                    throw new Exception("The quantity requested is bigger than quantity available");
                }
                int id = await _context.ProductsEcommerceDB.Where(x => x.Id == productDTO.Id).Select(x => x.Id).FirstOrDefaultAsync();
                if (id <= 0)
                {
                    throw new Exception("Was not found a matching id");
                }
                var products = new Products
                {
                    Id = id,
                    Title = await _context.ProductsEcommerceDB.Where(x => x.Id == productDTO.Id).Select(x => x.Title).FirstOrDefaultAsync(),
                    Price = await _context.ProductsEcommerceDB.Where(x => x.Id == productDTO.Id).Select(x => x.Price).FirstOrDefaultAsync(),
                    Available = (quantityAvailable - productDTO.Requested)
                };
                _context.ProductsEcommerceDB.Update(products);
                await _context.SaveChangesAsync();
                return products;
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
                _context.ProductsEcommerceDB.Add(product);
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
                var response = await _context.ProductsEcommerceDB.FindAsync(id);
                _context.ProductsEcommerceDB.Remove(response);
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
