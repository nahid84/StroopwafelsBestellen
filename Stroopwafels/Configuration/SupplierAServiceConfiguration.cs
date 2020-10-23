using Ordering;
using System.Configuration;

namespace Stroopwafels.Configuration
{
    public class SupplierAServiceConfiguration : ISupplierServiceConfiguration
    {
        public string GetProductsUri()
        {
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierA.ProductsUri;
        }
        public string GetOrderUri()
        {
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierA.OrderUri;
        }
    }
}