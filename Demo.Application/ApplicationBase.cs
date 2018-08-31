using System.Collections.Generic;
using Demo.Domain.Interface;
using Demo.Domain.Interface.Application;
using Demo.Domain.Interface.Service;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Application
{
    public class ApplicationBase<TEntity>: IApplicationBase<TEntity> where TEntity: class
    {
        private IUnitOfWork _unitOfWork;
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase, IRepositoryBase<TEntity> repositoryBase)
        {
            _serviceBase = serviceBase;
            _repositoryBase = repositoryBase;
        }

        public void Add(TEntity obj)
        {
            BeginTransaction();
            _repositoryBase.Add(obj);
            Commit();
        }

        public virtual void BeginTransaction()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _unitOfWork.BeginTransaction();
        }

        public virtual void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Delete(TEntity obj)
        {
            BeginTransaction();
            _repositoryBase.Delete(obj);
            Commit();
        }

        public void Delete(int id)
        {
            BeginTransaction();
            _repositoryBase.Delete(id);
            Commit();
        }

        public TEntity Get(int id)
        {
            return _repositoryBase.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            BeginTransaction();
            _repositoryBase.Update(obj);
            Commit();
        }
    }
}
