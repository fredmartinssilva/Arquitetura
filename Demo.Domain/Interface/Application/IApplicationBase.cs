using System.Collections.Generic;

namespace Demo.Domain.Interface.Application
{
    public interface IApplicationBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
    }
}
