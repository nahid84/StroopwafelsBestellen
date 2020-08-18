using Ordering;
using System.Configuration;

namespace Stroopwafels.Configuration
{
    public class SupplierCServiceConfiguration : ISupplierServiceConfiguration
    {
        public string GetProductsUri() 
        { 
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierC.ProductsUri; 
        }
        public string GetOrderUri() 
        {
            return (ConfigurationManager.GetSection("SuppliersSection") as SuppliersSection).SupplierC.OrderUri;
        }
    }
}