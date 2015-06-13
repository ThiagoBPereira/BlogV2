using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Dominio.Servicos
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepositorio<TEntity> _repositorio;

        public BaseService(IBaseRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }
        public void Create(TEntity obj)
        {
            _repositorio.Create(obj);
        }

        public TEntity Details(Guid id)
        {
            return _repositorio.Details(id);
        }

        public IEnumerable<TEntity> ListAllByUser(string name)
        {
            return _repositorio.ListAllByUser(name);
        }

        public void Edit(TEntity obj)
        {
            _repositorio.Edit(obj);
        }

        public void Delete(TEntity obj)
        {
            _repositorio.Delete(obj);
        }
    }
}
