using System;
using System.Collections.Generic;

namespace TBP.Blog.Dominio.Interfaces.Servicos
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Create(TEntity obj);

        TEntity Details(Guid id);

        IEnumerable<TEntity> ListAllByUser(string username);

        void Edit(TEntity obj);

        void Delete(TEntity obj);
    }
}
