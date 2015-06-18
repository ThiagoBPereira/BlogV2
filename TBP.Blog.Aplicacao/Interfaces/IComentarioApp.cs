using System;
using System.Collections.Generic;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Aplicacao.Interfaces
{
    public interface IComentarioApp
    {
        IEnumerable<ComentarioViewModel> ListAllByPost(Guid idPost);

        void Create(ComentarioViewModel obj);
    }
}