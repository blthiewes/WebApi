using System;
using System.Collections.Generic;using System.Data;

namespace RestfulApi.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbCommand CreateCommand();
        void SaveChanges();
        void Rollback();
    }
}
