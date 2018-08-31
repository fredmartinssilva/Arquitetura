using Demo.Domain.Interface;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Demo.Infra.Repository.Config
{
    public class UnitOfWork : IUnitOfWork
    {
        private ArquiteturaContext arquiteturaContext;

        public void BeginTransaction()
        {
            //arquiteturaContext = (GerenciadorDeRepositorioHttp)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();            
            arquiteturaContext = ServiceLocator.Current.GetInstance<ArquiteturaContext>();
        }

        public void Commit()
        {
            arquiteturaContext.SaveChanges();
        }
    }
}
