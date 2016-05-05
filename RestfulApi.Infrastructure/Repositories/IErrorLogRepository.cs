using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Infrastructure.Repositories
{
    public interface IErrorLogRepository
    {
        void LogClientError(string userName, string userAgent, string message, string stackTrace, string url, string ip);
        void LogServerError(Exception exception, string userName, string impersonatedBy);
    }
}
