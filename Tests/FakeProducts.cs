using EcommerceAPI.Facades;
using EcommerceAPI.Models;

namespace Tests
{
    public class FakeProducts : IProductsRepository
    {
        private readonly List<Products> _products;
        public FakeProducts()
        {
            _products = new List<Products>()
            {
                new Products() { Id = 1, Title = "title1", Category = "cel1",
                                   Photo = "photo1", Price = 165, Available = 100 },
                new Products() { Id = 2, Title = "title2", Category = "cel2",
                                   Photo = "photo2", Price = 265, Available = 200 },
                new Products() { Id = 3, Title = "title3", Category = "cel3",
                                   Photo = "photo3", Price = 365, Available = 300 },
                new Products() { Id = 4, Title = "title4", Category = "cel4",
                                   Photo = "photo4", Price = 465, Available = 400 },
                new Products() { Id = 5, Title = "title5", Category = "cel5",
                                   Photo = "photo5", Price = 565, Available = 500 },
            };
        }
        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return _products;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return _products.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task<Products> PatchProductAsync(int id, int requested)
        {
            var product = _products.Where(a => a.Id == id).FirstOrDefault();
            DeleteProductAsync(id);
            product.Available = product.Available - requested;

            if (product.Available < 0)
                return null;

            PostProductAsync(product);
            return product;
        }

        public async Task<Products> PostProductAsync(Products products)
        {
            products.Id = GeraId();

            if (products.Title == null)
                return null;

            _products.Add(products);
            return products;
        }

        public async Task<Products> DeleteProductAsync(int id)
        {
            var item = _products.First(a => a.Id == id);
            _products.Remove(item);
            return item;
        }
    }
}
