using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Umbraco.DynamicExample.Models
{
    public class MyRenderModel : RenderModel
    {
        public MyRenderModel(IPublishedContent content, CultureInfo culture) : base(content, culture)
        {
        }

        public MyRenderModel(IPublishedContent content) : base(content)
        {
        }

        public MyRenderModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        {
        }

        public string Id { get; set; }
    }
}