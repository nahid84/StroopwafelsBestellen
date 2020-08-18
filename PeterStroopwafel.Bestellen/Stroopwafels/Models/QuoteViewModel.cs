using System.Collections.Generic;

namespace Stroopwafels.Models
{
    public class QuoteViewModel
    {
        public IList<Quote> Quotes { get; set; }

        public IList<OrderRow> OrderRows { get; set; }

        public string SelectedSupplier { get; set; }

        public QuoteViewModel()
        {
            this.Quotes = new List<Quote>();
            this.OrderRows = new List<OrderRow>();
        }
    }
}