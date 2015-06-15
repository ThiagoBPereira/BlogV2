using System;
using System.Collections.Generic;
using AutoMapper;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Aplicacao.App
{
    public class PostApp : BaseApp, IPostApp
    {
        private readonly IPostService _postService;

        public PostApp(IPostService postService)
        {
            _postService = postService;
        }

        public IEnumerable<PostViewModel> ListAllByUser(string username, int indexPagina, int qtddPorPagina)
        {
            return Mapper.Map<List<PostViewModel>>(_postService.ListAllByUser(username, indexPagina, qtddPorPagina));
        }

        public void CreatePost(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);

            BeginTransaction();

            if (_postService.Create(kk).IsValid)
                Commit();
        }

        public void Update(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);

            BeginTransaction();

            if (_postService.Edit(kk).IsValid)
                Commit();
        }

        public void Delete(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);

            BeginTransaction();

            _postService.Delete(kk);

            Commit();
        }

        public PostViewModel Details(Guid id)
        {
            return Mapper.Map<PostViewModel>(_postService.Details(id));
        }

        public IEnumerable<PostViewModel> GetByTagName(string username, string tag, int indexPagina, int qtddPorPagina)
        {
            return Mapper.Map<List<PostViewModel>>(_postService.GetByTagName(username, tag, indexPagina, qtddPorPagina));
        }

        public int ObterTotalRegistros(string username)
        {
            return _postService.ObterTotalRegistros(username);
        }

        public int ObterTotalRegistrosByTag(string username, string tag)
        {
            return _postService.ObterTotalRegistrosByTag(username, tag);
        }
    }
}