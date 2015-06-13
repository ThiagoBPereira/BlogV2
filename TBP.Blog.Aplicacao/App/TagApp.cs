using System.Collections.Generic;
using AutoMapper;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Aplicacao.App
{
    public class TagApp : BaseApp, ITagApp
    {
        private readonly ITagService _itag;

        public TagApp(ITagService tag)
        {
            _itag = tag;
        }

        public IEnumerable<TagViewModel> ListAllByUser(string username)
        {
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_itag.ListAllByUser(username));
        }
        public IEnumerable<TagViewModel> GetByName(string username, string nome)
        {
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_itag.GetByName(username, nome));
        }

    }
}