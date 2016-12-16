using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;

namespace Umbraco.DynamicExample.App_Code
{
    public class MyRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            //var path = requestContext.HttpContext.Request.Url.GetAbsolutePathDecoded();

            // have we got a node with ID 1234?
            var contentCache = UmbracoContext.Current.ContentCache;
            var parent = contentCache.GetByRoute("/parent");
            if (parent == null)
                throw new ApplicationException("No Parent");

            var children = parent.Children.ToList();
            if (children == null || !children.Any())
                throw new ApplicationException("No Children");

            var content = children.First();

            if (content == null) throw new ApplicationException("No Content"); // not found          

            // render that node
            return content;
        }
    }
}