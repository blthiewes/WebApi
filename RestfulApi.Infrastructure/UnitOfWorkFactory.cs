using System.Data.SqlClient;
using RestfulApi.Domain.Repositories;

namespace RestfulApi.Infrastructure
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;
        private readonly bool _ownsConnection;

        public UnitOfWorkFactory(string connectionString, bool ownsConnection)
        {
            _connectionString = connectionString;
            _ownsConnection = ownsConnection;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(new SqlConnection(_connectionString), _ownsConnection);
        }
    }
}
