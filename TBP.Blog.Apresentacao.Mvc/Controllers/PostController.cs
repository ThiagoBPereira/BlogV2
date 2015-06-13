using System.Web.Mvc;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Aplicacao.ViewModels;
using Microsoft.AspNet.Identity;
using System;

namespace TBP.Blog.Apresentacao.Mvc.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        #region ctor
        private readonly IPostApp _postApp;
        public PostController(IPostApp postApp)
        {
            _postApp = postApp;
        }
        #endregion

        #region Anonimos
        [HttpGet, AllowAnonymous, Route("{userid}")]
        public ActionResult Index(string userid)
        {
            return Index(userid, 1);
        }

        [HttpGet, AllowAnonymous, Route("{userid}/{pagina:int}")]
        public ActionResult Index(string userid, int pagina)
        {
            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserId() : userid;

            return View(_postApp.ListAllByUser(usuario, pagina, 5));
        }

        [HttpGet, AllowAnonymous, Route("Posts/{id:guid}")]
        public ActionResult Details(Guid id)
        {
            return View(_postApp.Details(id));
        }

        [HttpGet, AllowAnonymous, Route("Posts/Tag/{userid}/{tag}")]
        public ActionResult Tag(string userid, string tag)
        {
            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserId() : userid;
            return View(_postApp.GetByTagName(usuario, tag));
        }

        [HttpGet, AllowAnonymous]
        public PartialViewResult LastFive()
        {
            //Pegar Id da pagina do usuário em questão
            var userid = RouteData.Values["userid"] as string;

            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserId() : userid;

            return PartialView("_LastFive", _postApp.ListAllByUser(usuario, 1, 5));
        }
        #endregion

        #region Autorizados
        [HttpGet, Authorize, Route("Admin/Post/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Authorize, Route("Admin/Post/Create")]
        public ActionResult Create(PostViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);

            _postApp.CreatePost(model);
            return RedirectToAction("Index", new { Area = "", name = User.Identity.GetUserId() });
        }

        [HttpGet, Authorize, Route("Admin/Post/Edit/{id:guid?}")]
        public ActionResult Edit(Guid id)
        {
            return View(_postApp.Details(id));
        }

        [HttpPost, Authorize, Route("Admin/Post/Edit")]
        public ActionResult Edit(PostViewModel model)
        {
            if (!ModelState.IsValid) return View();

            _postApp.Update(model);
            return RedirectToAction("Index", new { Area = "" });
        }

        #endregion
    }
}