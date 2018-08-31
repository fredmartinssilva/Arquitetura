using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Interface
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
    }
}
