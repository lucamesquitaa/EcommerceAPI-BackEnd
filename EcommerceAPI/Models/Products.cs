namespace EcommerceAPI.Models
{
    public class Products
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }
        public int Requested { get; set; }
        public int? Available { get; set; }

    }
}
