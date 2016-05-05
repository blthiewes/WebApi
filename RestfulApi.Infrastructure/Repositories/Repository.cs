using System;
using RestfulApi.Domain.Repositories;

namespace RestfulApi.Infrastructure.Repositories
{
    public abstract class Repository
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;

        }
    }
}
