using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kandoe.Web.Api.Controllers {
    public class DocumentationController : Controller {
        // GET: /
        public ActionResult Index() {
            return RedirectToAction("Index", "Help");
        }
    }
}