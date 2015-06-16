using System.Web.Mvc;

namespace TBP.Blog.Apresentacao.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error403()
        {
            ViewBag.CustomError = "Você não tem permissão para acessar esta página";
            return View("CustomError");
        }
    }
}