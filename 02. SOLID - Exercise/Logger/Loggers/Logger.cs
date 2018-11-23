namespace Solid.Logger.Loggers
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Loggers.Contracts;

    public class Logger : ILogger
    {
        private readonly IAppender appender;

        public Logger(IAppender  appender)
        {
            this.appender = appender;
        }

        public void Error(string dateTime, string errorMsg)
        {
            this.appender.Append(dateTime, "Error", errorMsg);
        }

        public void Info(string dateTime, string infoMsg)
        {
            this.appender.Append(dateTime, "Info", infoMsg);
        }
    }
}
