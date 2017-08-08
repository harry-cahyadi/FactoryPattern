using Experiment.Lib.Core;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Experiment.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register the application dependencies
            RegisterDIContainer();
        }

        private void RegisterDIContainer()
        {
            var container = new Container();

            // Register the dependencies
            DI.Register(container);

            // Sets the resolver to be used throughout the application
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
