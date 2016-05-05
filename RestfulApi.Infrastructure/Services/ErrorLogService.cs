using System;
using RestfulApi.Infrastructure.Repositories;
using RestfulApi.Infrastructure.Services.Interfaces;

namespace RestfulApi.Infrastructure.Services
{
    public class ErrorLogService : IErrorLogService
    {

        private readonly IErrorLogRepository _errorLogRepository;

        public ErrorLogService(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public void LogClientError(string userName, string userAgent, string message, string stackTrace, string url, string ip)
        {
            _errorLogRepository.LogClientError(userName, userAgent, message, stackTrace, url, ip);
        }

        public void LogServerError(Exception exception, string userName, string impersonatedBy)
        {
            _errorLogRepository.LogServerError(exception, userName, impersonatedBy);
        }


        public void LogServerError(Exception exception)
        {
            LogServerError(exception, string.Empty, string.Empty);
        }
    }
}
