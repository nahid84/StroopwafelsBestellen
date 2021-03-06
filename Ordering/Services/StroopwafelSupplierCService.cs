﻿using System;
using System.Collections.Generic;

namespace Ordering.Services
{
    public class StroopwafelSupplierCService : StroopwafelSupplierServiceBase, IStroopwafelSupplierService
    {
        private readonly Uri ProductsUri;

        private readonly Uri OrderUri;

        public ISupplier Supplier => new SupplierC();

        public bool IsAvailable => true;

        public StroopwafelSupplierCService(IHttpClientWrapper httpClientWrapper,
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

            return builder.CreateOrder(orderDetails, stroopwafels, new SupplierC());
        }

        public void Order(IList<KeyValuePair<StroopwafelType, int>> quoteLines)
        {
            var builder = new OrderBuilder();
            Order order = builder.CreateOrder(quoteLines);
            base.ExecutePost(OrderUri, order);
        }
    }
}