using System.Web.Mvc;

namespace TBP.Blog.Apresentacao.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Demo de Blog - Estudo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "thiag.bpereira@gmail.com";

            return View();
        }
    }
}