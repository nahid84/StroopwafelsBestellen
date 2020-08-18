using Ordering;
using Ordering.Commands;
using Ordering.Queries;
using Ordering.Services;
using Stroopwafels.Configuration;
using System;
using Unity;
using Unity.Injection;

namespace Stroopwafels
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IHttpClientWrapper, HttpClientWrapper>();

            container.RegisterType<IStroopwafelSupplierService, StroopwafelSupplierAService>("SupplierA",
                new InjectionConstructor(typeof(IHttpClientWrapper), typeof(SupplierAServiceConfiguration)));
            container.RegisterType<IStroopwafelSupplierService, StroopwafelSupplierBService>("SupplierB",
                new InjectionConstructor(typeof(IHttpClientWrapper), typeof(SupplierBServiceConfiguration)));
            container.RegisterType<IStroopwafelSupplierService, StroopwafelSupplierCService>("SupplierC",
                new InjectionConstructor(typeof(IHttpClientWrapper), typeof(SupplierCServiceConfiguration)));

            container.RegisterType<QuotesQueryHandler>();
            container.RegisterType<OrderCommandHandler>();
        }
    }
}