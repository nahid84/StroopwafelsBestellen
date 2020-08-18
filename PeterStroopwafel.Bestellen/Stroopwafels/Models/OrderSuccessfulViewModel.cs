using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stroopwafels.Models
{
    public class OrderSuccessfulViewModel
    {
        public string SelectedSupplier { get; set; }
        public int Quantity { get; set; }
        public string TotalAmount { get; set; }
    }
}