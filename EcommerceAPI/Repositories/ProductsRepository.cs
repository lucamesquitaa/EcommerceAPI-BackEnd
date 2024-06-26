﻿using EcommerceAPI.Calculator;
using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApiContext _context;
        private readonly IProductCalculator _calculator;
        public ProductsRepository(ApiContext context,
                                  IProductCalculator calculator)
        {
            _context = context;
            _calculator = calculator;
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            try
            {
                var response = await _context.productosAPIv1.AsNoTracking().ToListAsync();

                if (response == null)
                    throw new Exception();

                return response;
            }catch(Exception)
            {
                return null;
            }
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _context.productosAPIv1.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (response == null)
                    throw new Exception();

                return response;
            }catch(Exception)
            {
                return null;
            }
        }

        public async Task<Products> PutProductAsync(int id, int requested)
        {
            try
            {
                Products? product = await _context.productosAPIv1.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    throw new Exception();

                int newAvailable = _calculator.QuantityAvailableCalculator(product, requested);

                product.Available = newAvailable;

                _context.productosAPIv1.Update(product);
                await _context.SaveChangesAsync();

                return product;
            }catch(Exception)
            {
                return null;
            }
        }
        
        public async Task<Products> PostProductAsync(Products product)
        {
            try
            {
                _context.productosAPIv1.Add(product);
                await _context.SaveChangesAsync();

                return product;
            }catch(Exception)
            {
                return null;
            }
        }

        public async Task<Products> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _context.productosAPIv1.FindAsync(id);

                if(response == null)
                    throw new Exception();

                _context.productosAPIv1.Remove(response);
                await _context.SaveChangesAsync();

                return response;
            }catch(Exception)
            {
                return null;
            }
        }

    }
}
