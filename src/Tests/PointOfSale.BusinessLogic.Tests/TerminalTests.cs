using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSale.BusinessLogic;
using PointOfSale.Data.Entities;

namespace PointOfSale.BusinessLogic.Tests
{
    [TestClass]
    public class TerminalTests
    {
        private Terminal Terminal;

        private const double priceA = 1.25;
        private const double priceB = 4.25;
        private const double priceC = 1;
        private const double priceD = 0.75;

        private const double salePriceA = 3;
        private const double salePriceC = 5;
        private const int countForSalePriceA = 3;
        private const int countForSalePriceC = 6;

        [TestInitialize]
        public void Setup()
        {
            Terminal = GetPointOfSaleTerminal();
        }

        [TestMethod]
        public void CalculateTotal_ShoouldReturnProductPrice_WhenScanOneProduct()
        {
            ScanCalculateAndCheckResult(priceA, 'A');
        }

        [TestMethod]
        public void CalculateTotal_ShoouldReturnProductSalePrice_WhenScanExpectedForSaleCountOfProduct()
        {
            ScanCalculateAndCheckResult(salePriceA, 'A', 'A', 'A');
        }

        [TestMethod]
        public void CalculateTotal_ShoouldReturnProductSalePricePlasNormalPrice_WhenScanExpectedForSaleCountOfProductPlasOne()
        {
            ScanCalculateAndCheckResult(salePriceA + priceA, 'A', 'A', 'A', 'A');
        }

        [TestMethod]
        public void CalculateTotal_SpecialCheck1()
        {
            ScanCalculateAndCheckResult(13.25, 'A', 'B', 'C', 'D', 'A', 'B', 'A');
        }

        [TestMethod]
        public void CalculateTotal_SpecialCheck2()
        {
            ScanCalculateAndCheckResult(6, 'C', 'C', 'C', 'C', 'C', 'C', 'C');
        }

        [TestMethod]
        public void CalculateTotal_SpecialCheck3()
        {
            ScanCalculateAndCheckResult(7.25, 'A', 'B', 'C', 'D');
        }

        private void ScanCalculateAndCheckResult(double expectedResult, params char[] codes)
        {
            foreach (var code in codes)
                Terminal.Scan(code);

            var result = Terminal.CalculateTotal();

            Assert.AreEqual(expectedResult, result);
        }

        private Terminal GetPointOfSaleTerminal()
        {
            var terminal = new Terminal();
            var pricing = new List<ProductPrice>
            {
                new ProductPrice { Code = 'A', Price = priceA, Sale = new ProductSale { Count = countForSalePriceA, Price = salePriceA } },
                new ProductPrice { Code = 'B', Price = priceB },
                new ProductPrice { Code = 'C', Price = priceC, Sale = new ProductSale { Count = countForSalePriceC, Price = salePriceC } },
                new ProductPrice { Code = 'D', Price = priceD },
            };

            terminal.SetPricing(pricing);
            return terminal;
        }
    }
}
