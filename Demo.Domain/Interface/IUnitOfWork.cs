using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();
    }
}
