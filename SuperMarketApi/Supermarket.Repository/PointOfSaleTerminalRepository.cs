using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Repository
{

    public class PointOfSaleTerminalRepository : IPointOfSaleTerminalRepository
    {
        public void ClearBasket()
        {
            MockDB.Basket.Clear();
            SetCurrentPrice(0.00m);
        }

        public List<Basket> GetBasket()
        {
            return MockDB.Basket;
        }

        public List<ProductDiscount> GetProductDiscounts()
        {
            return MockDB.ProductDiscounts;
        }

        public decimal ScanProduct(string productCode)
        {
            return MockDB.AddItem(productCode);
        }

        public decimal SetCurrentPrice(decimal price)
        {
            return MockDB.currentPrice = price;
        }
    }

    public static class MockDB
    {
        public static List<Product> Products = new List<Product>();
        public static List<ProductDiscount> ProductDiscounts = new List<ProductDiscount>();
        public static List<Basket> Basket = new List<Basket>();
        public static decimal currentPrice;
        static MockDB()
        {
            Products.Add(new Product("A", 1.25m));
            Products.Add(new Product("B", 4.25m));
            Products.Add(new Product("C", 1.00m));
            Products.Add(new Product("D", 0.75m));

            ProductDiscounts.Add(new ProductDiscount("A", 3, 0.75m));
            ProductDiscounts.Add(new ProductDiscount("C", 6, 1.00m));
        }

        public static decimal AddItem(string productCode)
        {
            Basket.Add(new Basket() { ProductCode = productCode });
            currentPrice = currentPrice + Products.Find(p => p.ProductCode == productCode).Price;
            return currentPrice;
        }
    }

    public class Basket
    {
        public string ProductCode { get; set; }
        public bool DiscountApplied { get; set; }
    }
    public class Product
    {
        public Product(string code, decimal price)
        {
            ProductCode = code;
            Price = price;
        }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductDiscount
    {
        public ProductDiscount(string code, int discountCount, decimal discountValue)
        {
            ProductCode = code;
            DiscountCount = discountCount;
            DiscountValue = discountValue;
        }
        public string ProductCode { get; set; }
        public int DiscountCount { get; set; }
        public decimal DiscountValue { get; set; }
    }

}
