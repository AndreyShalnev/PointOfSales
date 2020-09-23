using PointOfSale.Data.Entities;
using System.Collections.Generic;

namespace PointOfSale.DataAccess.Mocks
{
    //In the real app Product Price will store in DB, this class used only for testing on the begining
    public class ProductPriceRepositoryMock : IRepository<ProductPrice>
    {
        private static List<ProductPrice> ProductPrices = new List<ProductPrice>
        {
            new ProductPrice { Code = 'A', Price = 1.25, Sale = new ProductSale { Count = 3, Price = 3 } },
            new ProductPrice { Code = 'B', Price = 4.25 },
            new ProductPrice { Code = 'C', Price = 1, Sale = new ProductSale { Count = 6, Price = 5 } },
            new ProductPrice { Code = 'D', Price = 0.75 },
        };

        public IEnumerable<ProductPrice> GetAll()
        {
            return ProductPrices;
        }
    }
}
