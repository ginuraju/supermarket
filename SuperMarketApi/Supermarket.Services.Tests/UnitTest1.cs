using System;
using Xunit;

namespace Supermarket.Services.Tests
{
    public class UnitTest1
    {
        [TestFixture]
        public class PrimeService_IsPrimeShould
        {
            private readonly IPointOfSaleTerminalService _primeService;

            public PrimeService_IsPrimeShould()
            {
                _primeService = new PrimeService();
            }

            [Test]
            public void ReturnFalseGivenValueOf1()
            {
                var result = _primeService.IsPrime(1);

                Assert.IsFalse(result, "1 should not be prime");
            }

        }
    }
}
