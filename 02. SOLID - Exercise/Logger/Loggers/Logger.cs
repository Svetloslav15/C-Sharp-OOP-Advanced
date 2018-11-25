namespace Solid.Logger.Loggers
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Loggers.Contracts;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }
        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public void Error(string dateTime, string errorMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.Error, errorMsg);
        }
        public void Warning(string dateTime, string errorMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.Warning, errorMsg);
        }
        public void Fatal(string dateTime, string msg)
        {
            this.consoleAppender.Append(dateTime, ReportLevel.Fatal, msg);
        }
        public void Critical(string dateTime, string msg)
        {
            this.consoleAppender.Append(dateTime, ReportLevel.Critical, msg);
        }
        public void Info(string dateTime, string infoMsg)
        {
            this.AppendMessage(dateTime, ReportLevel.Info, infoMsg);
        }
        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.fileAppender?.Append(dateTime, reportLevel, message);
            this.consoleAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
