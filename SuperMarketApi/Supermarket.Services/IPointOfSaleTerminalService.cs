using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public interface IPointOfSaleTerminalService
    {
        decimal ScanProduct(string productCode);
    }
}
