using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Infra.Data.Contexto;
using TBP.Blog.Infra.Data.Interfaces;

namespace TBP.Blog.Infra.Data.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        protected DbSet<TEntity> DbSet;
        protected BlogContexto Contexto;
        public BaseRepositorio()
        {
            Contexto = _contextManager.GetContext();
            DbSet = Contexto.Set<TEntity>();
        }


        public void Create(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity Details(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ListAllByUser(string username)
        {
            return DbSet.ToListAsync().Result;
        }
        //TODO 7: Tratar concorrencia de dados
        public void Edit(TEntity obj)
        {
            Contexto.Set<TEntity>().Attach(obj);
            Contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
        {
            DbSet.Remove(obj);
        }
    }
}