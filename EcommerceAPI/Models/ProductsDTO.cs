using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class ProductsDTO
    {
        [Required]
        public int Requested { get; set; }
    }
}
