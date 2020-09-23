using PointOfSale.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.BusinessLogic
{
    public class Terminal : ITerminal
    {
        private IEnumerable<ProductPrice> Pricing;
        private List<char> ProductCodes = new List<char>();

        public void SetPricing(IEnumerable<ProductPrice> pricing)
        {
            Pricing = pricing;
        }

        public void Scan(char productCode)
        {
            ProductCodes.Add(productCode);
        }

        public double CalculateTotal()
        {
            var groupedProductCodes = ProductCodes.GroupBy(i => i);
            double totalPrice = 0;

            foreach (var productCodes in groupedProductCodes)
            {
                totalPrice += CalculateCodePrice(productCodes.Key, productCodes.Count());
            }

            return totalPrice;
        }

        private double CalculateCodePrice(char productCode, int count)
        {
            double salePrice = 0;
            var productPrice = Pricing.First(i => i.Code == productCode);

            if (productPrice.Sale?.Count <= count)
            {
                salePrice = count / productPrice.Sale.Count * productPrice.Sale.Price;
                count %= productPrice.Sale.Count;
            }

            return salePrice + count * productPrice.Price;
        }
    }
}
