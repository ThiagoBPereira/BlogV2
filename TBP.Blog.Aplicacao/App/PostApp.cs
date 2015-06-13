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

        public List<PostViewModel> ListAllByUser(string username)
        {
            return Mapper.Map<List<PostViewModel>>(_postService.ListAllByUser(username));
        }

        public IEnumerable<PostViewModel> ListAllByUser(string username, int indexPagina, int qtddPorPagina)
        {
            return Mapper.Map<List<PostViewModel>>(_postService.ListAllByUser(username, indexPagina, qtddPorPagina));
        }

        public void CreatePost(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);

            if (!kk.IsValid())
            {
                //Retornar o erro ao usuário
                return;
            }

            BeginTransaction();

            _postService.Create(kk);

            Commit();
        }

        public void Update(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);
            if (!kk.IsValid())
            {
                //Retornar o erro ao usuário
                return;
            }

            BeginTransaction();

            _postService.Edit(kk);

            Commit();
        }

        public void Delete(PostViewModel post)
        {
            var kk = Mapper.Map<Post>(post);
            if (!kk.IsValid())
            {
                //Retornar o erro ao usuário
                return;
            }

            BeginTransaction();

            _postService.Delete(kk);

            Commit();
        }

        public PostViewModel Details(Guid id)
        {
            return Mapper.Map<PostViewModel>(_postService.Details(id));
        }

        public IEnumerable<PostViewModel> GetByTagName(string username, string tag)
        {
            return Mapper.Map<List<PostViewModel>>(_postService.GetByTagName(username, tag));
        }
    }
}