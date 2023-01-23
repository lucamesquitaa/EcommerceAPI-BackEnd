using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace EcommerceAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Products> ContextProductsAPI { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
    }
}
