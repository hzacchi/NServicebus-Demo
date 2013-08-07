using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using log4net.Appender;
using log4net.Core;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Configure.ScaleOut(s => s.UseSingleBrokerQueue());

            bus = Configure.With()
                     .DefaultBuilder()
                     .Log4Net(new DebugAppender { Threshold = Level.Warn })
                     .UseTransport<Msmq>()
                     .PurgeOnStartup(false)
                     .UnicastBus()
                     .RunHandlersUnderIncomingPrincipal(false)
                     //.RijndaelEncryptionService()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
                                           .Install());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static IBus bus;
        public static IBus Bus
        {
            get { return bus; }
        }
    }
}