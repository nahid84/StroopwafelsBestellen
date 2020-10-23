using System.Configuration;

namespace Stroopwafels.Configuration
{
    public class SupplierConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("ProductsUri", IsRequired = true)]
        public string ProductsUri
        {
            get { return this["ProductsUri"] as string; }
            set { value = this["ProductsUri"] as string; }
        }

        [ConfigurationProperty("OrderUri", IsRequired = true)]
        public string OrderUri
        {
            get { return this["OrderUri"] as string; }
            set { value = this["OrderUri"] as string; }
        }

    }
}