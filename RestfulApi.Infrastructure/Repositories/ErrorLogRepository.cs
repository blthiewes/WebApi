using System;
using NLog;

namespace RestfulApi.Infrastructure.Repositories
{
    public class ErrorLogRepository : IErrorLogRepository
    {

        private static readonly Logger ClientSideLogger = LogManager.GetLogger("ClientErrorLogger");
        private static readonly Logger ServerSideLogger = LogManager.GetLogger("ServerErrorLogger");
        public void LogClientError(string userName, string userAgent, string message, string stackTrace, string url, string ip)
        {
            var logEventInfo = new LogEventInfo(LogLevel.Error, ClientSideLogger.Name, message);
            logEventInfo.Properties.Add("UserName", userName);
            logEventInfo.Properties.Add("UserAgent", userAgent);
            logEventInfo.Properties.Add("StackTrace", stackTrace);
            logEventInfo.Properties.Add("Url", url);
            logEventInfo.Properties.Add("Ip", ip);
            ClientSideLogger.Log(typeof(ErrorLogRepository), logEventInfo);
        }

        public void LogServerError(Exception exception, string userName, string impersonatedBy)
        {
            var logEventInfo = new LogEventInfo(LogLevel.Error, ServerSideLogger.Name, exception.Message);
            logEventInfo.Properties.Add("UserName", userName);
            logEventInfo.Properties.Add("ImpersonatedBy", impersonatedBy ?? string.Empty);
            logEventInfo.Exception = exception;
            ServerSideLogger.Log(typeof(ErrorLogRepository), logEventInfo);
        }
    }
}
