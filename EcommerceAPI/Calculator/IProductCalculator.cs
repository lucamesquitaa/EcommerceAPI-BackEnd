using EcommerceAPI.Models;

namespace EcommerceAPI.Calculator
{
    public interface IProductCalculator
    {
        public int QuantityAvailableCalculator(Products product, int requested);
    }
}
