using Demo.Domain.Interface;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ArquiteturaContext arquiteturaContext;

        public RepositoryBase() {
            //arquiteturaContext = (GerenciadorDeRepositorioHttp)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
            arquiteturaContext = ServiceLocator.Current.GetInstance<ArquiteturaContext>();
        }
        
        public void Add(TEntity obj)
        {
            arquiteturaContext.Set<TEntity>().Add(obj);
        }

        public void Delete(TEntity obj)
        {
            arquiteturaContext.Set<TEntity>().Remove(obj);
        }

        public void Delete(int id)
        {
            TEntity obj = Get(id);
            Delete(obj);
        }

        public TEntity Get(int id)
        {
            return arquiteturaContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return arquiteturaContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            arquiteturaContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
