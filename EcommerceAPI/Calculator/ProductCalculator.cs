using EcommerceAPI.Models;

namespace EcommerceAPI.Calculator
{
    public class ProductCalculator : IProductCalculator 
    {
        public int QuantityAvailableCalculator(Products product, int requested)
        {
            if (requested > product.Available)
            {
                throw new Exception("Quantity requested is bigger than the quantity available.");
            }

            return product.Available - requested;
        }
    }
}
