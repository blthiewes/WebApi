using RestfulApi.Domain.Repositories;

namespace RestfulApi.Infrastructure
{
    public interface IRepositoryFactory
    {
        T Create<T>(IUnitOfWork unitOfWork);
        void Release(object repository);
    }
}
