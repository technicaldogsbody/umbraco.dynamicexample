using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.DynamicExample.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.DynamicExample.Controllers
{
    public class MyController : RenderMvcController
    {
        // GET: My
        public ActionResult Index(MyRenderModel model)
        {
            return base.Index(model);
        }
    }
}