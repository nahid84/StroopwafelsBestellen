using Ordering;
using System.Collections.Generic;
using System.Linq;

namespace Stroopwafels.Models
{
    public static class OrderRowsExtension
    {
        public static IList<KeyValuePair<StroopwafelType, int>> ToKeyValueList(this IList<OrderRow> orderRows)
        {
            return orderRows.Select(orderRow => new KeyValuePair<StroopwafelType, int>(orderRow.Type, orderRow.Amount))
                            .ToList();
        }
    }
}