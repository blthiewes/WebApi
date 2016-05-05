using RestfulApi.Domain.Repositories;

namespace RestfulApi.Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
