using System;
using System.Collections.Generic;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Aplicacao.Interfaces
{
    public interface IPostApp
    {
        IEnumerable<PostViewModel> ListAllByUser(string username, int indexPagina, int qtddPorPagina);

        void CreatePost(PostViewModel post);

        void Update(PostViewModel post);

        void Delete(PostViewModel post);

        PostViewModel Details(Guid id);

        IEnumerable<PostViewModel> GetByTagName(string username, string tag);
    }
}