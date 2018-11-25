namespace Solid.Logger.Appenders.Contracts
{
    using Solid.Logger.Loggers;

    public interface IAppender
    {
        void Append(string dateTime, ReportLevel errorLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }
    }
}