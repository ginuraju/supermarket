using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Repository
{
    public interface IPointOfSaleTerminalRepository
    {

        decimal ScanProduct(string productCode);
        List<Basket> GetBasket();
        List<ProductDiscount> GetProductDiscounts();
        decimal SetCurrentPrice(decimal price);
        void ClearBasket();
    }
}
