using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Stroopwafels
{
    public class MvcApplication : HttpApplication
    {
        private readonly string _startTimeKey;

        private DateTime StartTime
        {
            set { Application[_startTimeKey] = value; }
        }

        public MvcApplication()
        {
            this._startTimeKey = this.GetType().Namespace + ".StartTime";
        }

        protected void Application_Start()
        {
            StartTime = DateTime.Now;

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityMvcActivator.Start();
        }


    }
}
