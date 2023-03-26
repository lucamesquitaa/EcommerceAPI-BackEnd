using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Available { get; set; }

    }
}
