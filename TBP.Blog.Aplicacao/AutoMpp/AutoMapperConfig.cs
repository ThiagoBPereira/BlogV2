using AutoMapper;

namespace TBP.Blog.Aplicacao.AutoMpp
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModel>();
                x.AddProfile<ViewModelToDomain>();
            });


        }

    }
}
