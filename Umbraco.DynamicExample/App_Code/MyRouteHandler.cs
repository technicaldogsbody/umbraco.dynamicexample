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
            string path = requestContext.HttpContext.Request.Url.GetAbsolutePathDecoded();

            string rootPath = "/home";
            
            var language =  StringBefore(path);

            if (!string.IsNullOrEmpty(language)) rootPath = language;

            var contentCache = umbracoContext.ContentCache;
            var parent = contentCache.GetByRoute(rootPath + "/parent", false);
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

        public static string StringBefore(string s)
        {
            int l = s.IndexOf("/parent", StringComparison.Ordinal);
            return l > 0 ? s.Substring(0, l) : "";
        }
    }
}