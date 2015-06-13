using AutoMapper;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Aplicacao.AutoMpp
{
    public class DomainToViewModel : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModel"; }
        }

        protected override void Configure()
        {
            //Mappings
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<Comentario, ComentarioViewModel>();
        }
    }
}