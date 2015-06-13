using AutoMapper;
using TBP.Blog.Aplicacao.ViewModels;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Aplicacao.AutoMpp
{
    public class ViewModelToDomain : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomain"; }
        }

        protected override void Configure()
        {
            //Mappings
            Mapper.CreateMap<PostViewModel, Post>();
            Mapper.CreateMap<TagViewModel, Tag>();
            Mapper.CreateMap<ComentarioViewModel, Comentario>();
        }
    }
}