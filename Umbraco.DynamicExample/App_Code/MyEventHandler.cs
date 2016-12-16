using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace Umbraco.DynamicExample.App_Code
{
    public class MyEventHandler : ApplicationEventHandler
    { 

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            RouteTable.Routes.MapUmbracoRoute(
                "child",
                "parent/child/{id}",
                new
                {
                    action = "index",
                    controller = "my"
                },
                new MyRouteHandler());
        }
    }
}