using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Products>? ProductsDb { get; set; }
        protected ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
