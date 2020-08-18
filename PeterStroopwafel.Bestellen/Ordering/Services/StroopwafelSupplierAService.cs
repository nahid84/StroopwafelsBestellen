using System;
using System.Collections.Generic;

namespace Ordering.Services
{
    public class StroopwafelSupplierAService : StroopwafelSupplierServiceBase, IStroopwafelSupplierService
    {
        private readonly Uri ProductsUri;

        private readonly Uri OrderUri;

        public ISupplier Supplier => new SupplierA();

        public bool IsAvailable => true;

        public StroopwafelSupplierAService(IHttpClientWrapper httpClientWrapper,
                                           ISupplierServiceConfiguration config) : base(httpClientWrapper)
        {
            ProductsUri = new Uri(config.GetProductsUri());
            OrderUri = new Uri(config.GetOrderUri());
        }

        public Quote GetQuote(IList<KeyValuePair<StroopwafelType, int>> orderDetails)
        {
            var result = base.ExecuteGet(ProductsUri);
            var stroopwafels = result.ToObject<IList<Stroopwafel>>();

            var builder = new QuoteBuilder();

            return builder.CreateOrder(orderDetails, stroopwafels, new SupplierA());
        }

        public void Order(IList<KeyValuePair<StroopwafelType, int>> quoteLines)
        {
            var builder = new OrderBuilder();
            Order order = builder.CreateOrder(quoteLines);
            base.ExecutePost(OrderUri, order);
        }
    }
}