using Supermarket.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class PointOfSaleTerminalService : IPointOfSaleTerminalService
    {
        private readonly IPointOfSaleTerminalRepository _pointOfSaleTerminalRepository;
        public PointOfSaleTerminalService(IPointOfSaleTerminalRepository pointOfSaleTerminalRepository)
        {
            _pointOfSaleTerminalRepository = pointOfSaleTerminalRepository;
        }
        public decimal ScanProduct(string productCode)
        {
            var actualprice = _pointOfSaleTerminalRepository.ScanProduct(productCode);

            var currentBasket = _pointOfSaleTerminalRepository.GetBasket();

            var discountedPrice = ApplyDiscountsToEligibleProducts(currentBasket, actualprice);

            return discountedPrice;
        }

        public void ClearBasket()
        {
            _pointOfSaleTerminalRepository.ClearBasket();
        }

        private decimal ApplyDiscountsToEligibleProducts(List<Basket> currentBasket, decimal actualprice)
        {
            var price = actualprice;
            var currentDiscounts = _pointOfSaleTerminalRepository.GetProductDiscounts();
            foreach (var discountItem in currentDiscounts)
            {
                var eligibleItems = currentBasket.FindAll(c => c.ProductCode == discountItem.ProductCode && c.DiscountApplied == false);
                if (eligibleItems.Count == discountItem.DiscountCount)
                {
                    price = price - discountItem.DiscountValue;
                    eligibleItems.ForEach(e => e.DiscountApplied = true);
                }
            }
            _pointOfSaleTerminalRepository.SetCurrentPrice(price);
            return price;
        }
    }
}
