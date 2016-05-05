using System;
using System.Data;
using RestfulApi.Domain.Repositories;

namespace RestfulApi.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private readonly bool _ownsConnection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(IDbConnection connection, bool ownsConnection)
        {
            _connection = connection;
            _ownsConnection = ownsConnection;
            _connection.Open();
            _transaction = connection.BeginTransaction();
        }

        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction have already been commited. Check your transaction handling.");

            _transaction.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            if (_transaction == null)
                return;
            _transaction.Rollback();
            _transaction = null;
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                }

                if (_connection == null || !_ownsConnection) return;
                _connection.Close();
                _connection = null;
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
