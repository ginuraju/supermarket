using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Repository;

namespace Supermarket.Services.Test
{
    [TestClass]
    public class PointOfSaleTerminalServiceTest
    {
        private readonly PointOfSaleTerminalService _primeService;

        public PointOfSaleTerminalServiceTest()
        {
            _primeService = new PointOfSaleTerminalService(new PointOfSaleTerminalRepository());
        }

        [TestMethod]
        public void GivenProductsScanned_WhenProductsareABCDABA_Priceis1325()
        {
            _primeService.ClearBasket();

            _primeService.ScanProduct("A");
            _primeService.ScanProduct("B");
            _primeService.ScanProduct("C");
            _primeService.ScanProduct("D");
            _primeService.ScanProduct("A");
            _primeService.ScanProduct("B");
            var finalPrice = _primeService.ScanProduct("A");
            Assert.AreEqual(13.25m, finalPrice);
        }

        [TestMethod]
        public void GivenProductsScanned_WhenProductsareCCCCCCC_Priceis600()
        {
            _primeService.ClearBasket();

            _primeService.ScanProduct("C");
            _primeService.ScanProduct("C");
            _primeService.ScanProduct("C");
            _primeService.ScanProduct("C");
            _primeService.ScanProduct("C");
            _primeService.ScanProduct("C");
            var finalPrice = _primeService.ScanProduct("C");
            Assert.AreEqual(6.00m, finalPrice);
        }

        [TestMethod]
        public void GivenProductsScanned_WhenProductsareABCD_Priceis720()
        {
            _primeService.ClearBasket();

            _primeService.ScanProduct("A");
            _primeService.ScanProduct("B");
            _primeService.ScanProduct("C");
            var finalPrice = _primeService.ScanProduct("D");
            Assert.AreEqual(finalPrice, 7.25m);
        }
    }
}
