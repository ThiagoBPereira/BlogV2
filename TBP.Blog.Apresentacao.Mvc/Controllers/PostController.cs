using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Infra.CrossCutting.MvcFilters;

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
        [HttpGet, AllowAnonymous, Route("Posts/{userid}/{pagina:int?}")]
        public ActionResult Index(string userid, int pagina = 1)
        {
            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserName() : userid;

            //Montar Paginação
            ViewBag.TotalRegistros = _postApp.ObterTotalRegistros(usuario);
            ViewBag.PaginaAtual = pagina;

            // 5 = quantidade por pagina
            return View(_postApp.ListAllByUser(usuario, pagina, 5));
        }

        [HttpGet, AllowAnonymous, Route("Posts/{id:guid}")]
        public ActionResult Details(Guid id)
        {
            return View(_postApp.Details(id));
        }

        [HttpGet, AllowAnonymous, Route("Posts/{userid}/{tag}/{pagina:int?}")]
        public ActionResult Tag(string userid, string tag, int pagina = 1)
        {
            //TODO 6: Inserir paginação
            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserName() : userid;
            //Montar Paginação
            ViewBag.TotalRegistros = _postApp.ObterTotalRegistrosByTag(usuario, tag);
            ViewBag.PaginaAtual = pagina;

            return View("Index", _postApp.GetByTagName(usuario, tag, pagina, 5));
        }

        [HttpGet, AllowAnonymous]
        public PartialViewResult LastFive()
        {
            //Pegar Id da pagina do usuário em questão
            var userid = RouteData.Values["userid"] as string;

            var usuario = string.IsNullOrEmpty(userid) ? HttpContext.User.Identity.GetUserName() : userid;

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
            return RedirectToAction("Index", new { Area = "", userId = User.Identity.GetUserName() });
        }

        [HttpGet, EditAuthorize("userId"), Route("Admin/{userid}/Post/Edit/{id:guid?}")]
        public ActionResult Edit(Guid id)
        {
            return View(_postApp.Details(id));
        }

        [HttpPost, EditAuthorize("userId"), Route("Admin/{userid}/Post/Edit")]
        public ActionResult Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            _postApp.Update(model);
            return RedirectToAction("Index", new { Area = "" });
        }

        #endregion
    }
}