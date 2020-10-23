using Ordering;
using System.Configuration;

namespace Stroopwafels.Configuration
{
    public class SupplierBServiceConfiguration : ISupplierServiceConfiguration
    {
        public string GetProductsUri()
        {
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierB.ProductsUri;
        }
        public string GetOrderUri()
        {
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierB.OrderUri;
        }
    }
}