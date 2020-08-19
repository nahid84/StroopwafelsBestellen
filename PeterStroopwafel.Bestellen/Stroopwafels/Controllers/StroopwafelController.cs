using Ordering;
using Ordering.Commands;
using Ordering.Queries;
using Stroopwafels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Stroopwafels.Controllers
{
    public class StroopwafelController : Controller
    {
        private readonly QuotesQueryHandler _quotesQueryHandler;
        private readonly OrderCommandHandler _orderCommandHandler;

        public StroopwafelController(QuotesQueryHandler quotesQueryHandler,
                                     OrderCommandHandler orderCommandHandler)
        {
            _quotesQueryHandler = quotesQueryHandler;
            _orderCommandHandler = orderCommandHandler;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new OrderDetailsViewModel());
        }

        [HttpPost]
        public ActionResult GetQuotes(OrderDetailsViewModel formModel)
        {
            if (ModelState.IsValid)
            {
                var quotes = GetQuotesFor(formModel.OrderRows.ToKeyValueList());
                quotes = FilterOnDeliveryDate(quotes, formModel.DeliveryDate);

                var viewModel = new QuoteViewModel()
                {
                    Quotes = quotes.Select(quote => new Models.Quote { SupplierName = quote.Supplier.Name, TotalAmount = quote.TotalPricePresentation })
                                   .ToList(),
                    OrderRows = formModel.OrderRows,
                    SelectedSupplier = FindCheapestSupplier(quotes)
                };

                return View(viewModel);
            }

            return Index();
        }

        [HttpPost]
        public ActionResult Order(QuoteViewModel formModel)
        {
            if (ModelState.IsValid)
            {
                PlaceOrder(formModel.OrderRows.ToKeyValueList(), formModel.SelectedSupplier);

                var viewModel = new OrderSuccessfulViewModel()
                {
                    SelectedSupplier = formModel.SelectedSupplier,
                    Quantity = formModel.OrderRows.Sum(x => x.Amount),
                    TotalAmount = formModel.Quotes.Single(x => x.SupplierName.Equals(formModel.SelectedSupplier)).TotalAmount
                };

                return View(viewModel);
            }

            return Index();
        }

        private IList<Ordering.Quote> GetQuotesFor(IList<KeyValuePair<StroopwafelType, int>> orderDetails)
        {
            return _quotesQueryHandler.Handle(new QuotesQuery(orderDetails));
        }

        private IList<Ordering.Quote> FilterOnDeliveryDate(IList<Ordering.Quote> quotes, DateTime deliveryDate)
        {
            (quotes as List<Ordering.Quote>).RemoveAll(m => (deliveryDate.Date - DateTime.Now.Date).TotalDays < m.Supplier.DeliveryDays);

            return quotes;
        }

        private void PlaceOrder(IList<KeyValuePair<StroopwafelType, int>> orderDetails, string supplier)
        {
            _orderCommandHandler.Handle(new OrderCommand(orderDetails, supplier));
        }

        private string FindCheapestSupplier(IList<Ordering.Quote> quotes)
        {
            return quotes.OrderBy(q => q.TotalPrice)
                         .First().Supplier.Name;
        }

    }
}