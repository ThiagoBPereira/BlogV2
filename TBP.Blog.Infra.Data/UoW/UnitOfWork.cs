using System;
using Microsoft.Practices.ServiceLocation;
using TBP.Blog.Infra.Data.Contexto;
using TBP.Blog.Infra.Data.Interfaces;

namespace TBP.Blog.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContexto _contexto;

        private readonly ContextManager _contextManager =
            ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        private bool _disposed;

        public UnitOfWork()
        {
            _contexto = _contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}