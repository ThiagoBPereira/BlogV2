using System;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Interfaces.Servicos
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        ValidationResult Create(TEntity obj);

        TEntity Details(Guid id);

        ValidationResult Edit(TEntity obj);

        void Delete(TEntity obj);
    }
}
