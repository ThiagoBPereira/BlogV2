using System;
using System.Collections.Generic;
using AutoMapper;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Aplicacao.App
{
    public class ComentarioApp : BaseApp, IComentarioApp
    {
        private readonly IComentarioService _iComentarioService;

        public ComentarioApp(IComentarioService iComentarioService)
        {
            _iComentarioService = iComentarioService;
        }


        public IEnumerable<ComentarioViewModel> ListAllByPost(Guid idPost)
        {
            return Mapper.Map<IEnumerable<ComentarioViewModel>>(_iComentarioService.ListAllByPost(idPost));
        }

        public void Create(ComentarioViewModel obj)
        {
            var coment = Mapper.Map<Comentario>(obj);

            if (!coment.IsValid())
            {
                return;
            }
            BeginTransaction();

            _iComentarioService.Create(coment);

            Commit();
        }
    }
}