using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace EcommerceAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Products> productosAPIv1 { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
    }
}
