using Microsoft.Practices.ServiceLocation;
using TBP.Blog.Infra.Data.Interfaces;

namespace TBP.Blog.Aplicacao.App
{
    public class BaseApp
    {
        private IUnitOfWork _uow;

        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}