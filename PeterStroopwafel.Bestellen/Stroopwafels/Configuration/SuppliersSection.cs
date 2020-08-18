using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Stroopwafels.Configuration
{
    public class SuppliersSection : ConfigurationSection
    {
        [ConfigurationProperty("SupplierA", IsRequired = false)]
        public SupplierConfiguration SupplierA
        {
            get { return this["SupplierA"] as SupplierConfiguration; }
            set { value = this["SupplierA"] as SupplierConfiguration; }
        }

        [ConfigurationProperty("SupplierB", IsRequired = false)]
        public SupplierConfiguration SupplierB
        {
            get { return this["SupplierB"] as SupplierConfiguration; }
            set { value = this["SupplierB"] as SupplierConfiguration; }
        }

        [ConfigurationProperty("SupplierC", IsRequired = false)]
        public SupplierConfiguration SupplierC
        {
            get { return this["SupplierC"] as SupplierConfiguration; }
            set { value = this["SupplierC"] as SupplierConfiguration; }
        }
    }
}