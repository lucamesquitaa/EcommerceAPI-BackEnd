using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Products
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }

    }
}
