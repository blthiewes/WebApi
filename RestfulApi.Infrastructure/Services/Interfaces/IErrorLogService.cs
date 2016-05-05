using System;

namespace RestfulApi.Infrastructure.Services.Interfaces
{
    public interface IErrorLogService
    {
        void LogClientError(string userName, string userAgent, string message, string stackTrace, string url, string ip);
        void LogServerError(Exception exception, string userName, string impersonatedBy);
        void LogServerError(Exception exception);
    }
}
