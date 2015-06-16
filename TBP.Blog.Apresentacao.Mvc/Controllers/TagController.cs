using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using TBP.Blog.Aplicacao.App;

namespace TBP.Blog.Apresentacao.Mvc.Controllers
{
    public class TagController : Controller
    {
        private readonly TagApp _tagApp;
        public TagController(TagApp tagApp)
        {
            _tagApp = tagApp;
        }

        [HttpGet, Route("Admin/Tag/GetByName")]
        public string GetByName(string tag)
        {
            var usuario = User.Identity.GetUserName();
            var items = _tagApp.GetByName(usuario, tag);
            var retorno = JsonConvert.SerializeObject(items);
            return retorno;
        }
    }
}