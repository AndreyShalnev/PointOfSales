using PointOfSale.Data.Entities;
using System.Collections.Generic;

namespace PointOfSale.BusinessLogic
{
    public interface ITerminal
    {
        void SetPricing(IEnumerable<ProductPrice> pricing);
        void Scan(char productCode);
        double CalculateTotal();
    }
}
