using System.Web.Mvc;

namespace Kandoe.Web.Api.Controllers {
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