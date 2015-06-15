using Ninject.Modules;
using TBP.Blog.Aplicacao.App;
using TBP.Blog.Aplicacao.Interfaces;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;
using TBP.Blog.Dominio.Servicos;
using TBP.Blog.Infra.Data.Contexto;
using TBP.Blog.Infra.Data.Interfaces;
using TBP.Blog.Infra.Data.Repositorios;
using TBP.Blog.Infra.Data.UoW;

namespace TBP.Blog.Infra.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //APP
            Bind<IPostApp>().To<PostApp>();
            Bind<IComentarioApp>().To<ComentarioApp>();
            Bind<ITagApp>().To<TagApp>();

            //Repositorio
            Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            Bind<IPostRepositorio>().To<PostRepositorio>();
            Bind<IComentarioRepositorio>().To<ComentarioRepositorio>();
            Bind<ITagRepositorio>().To<TagRepositorio>();

            //Serviços
            //Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            Bind<ITagService>().To<TagService>();
            Bind<IPostService>().To<PostService>();
            Bind<IComentarioService>().To<ComentarioService>();

            //Data Config
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();


        }
    }
}