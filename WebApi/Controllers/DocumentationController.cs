using System.Collections.Generic;
using System.Web.Mvc;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers {
    public class DocumentationController : Controller {
        // GET: /
        public ActionResult Index() {
            return View("~/Views/Documentation/Index.cshtml");
        }

        // GET: /documentation/api
        public ActionResult Api() {
            return RedirectToAction("Index", "Help");
        }
    }
}