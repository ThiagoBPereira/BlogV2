using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TBP.Blog.Aplicacao.App;

namespace TBP.Blog.Apresentacao.Mvc.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly TagApp _tagApp;

        public TagController(TagApp tagApp)
        {
            _tagApp = tagApp;
        }

        // GET: Admin/Tag/GetByName
        [HttpGet, Route("Admin/Tag/GetByName")]
        public JsonResult GetByName(string term)
        {
            var usuario = User.Identity.GetUserId();
            var todas = _tagApp.GetByName(usuario, term);
            return Json(new { todas }, JsonRequestBehavior.AllowGet);
        }
    }
}