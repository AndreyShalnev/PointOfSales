using PointOfSale.Data;
using PointOfSale.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Core.Validators
{
    public static class ProductCodesValidator
    {
        public static ValidationResult Validate(string productCodes, IEnumerable<ProductPrice> productPrices)
        {
            var unknownProductCodes = productCodes.ToCharArray().Where(i => !productPrices.Any(p => p.Code == i));
            if (unknownProductCodes.Any())
                return new ValidationResult(false, $"Request contains unnown codes: {string.Join(",", unknownProductCodes.Distinct())}");

            return new ValidationResult(true);
        }
    }
}
