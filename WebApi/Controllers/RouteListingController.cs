using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kandoe.Web.Api.Controllers {
    public class RouteListingController : Controller {
        // GET: RouteListing
        public ActionResult Index() {
            return View();
        }
    }
}