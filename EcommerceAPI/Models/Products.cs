using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Photo { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Available { get; set; }

    }
}
