namespace Solid.Logger.Appenders
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers;
    using Solid.Logger.Loggers.Contracts;
    using System.IO;

    public class FileAppender : IAppender
    {
        private const string path = "../../../log.txt";
        private readonly ILayout layout;
        private readonly ILogFile logFile;
        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; private set; }

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }
        public void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (this.ReportLevel <= errorLevel)
            {
                this.MessagesCount++;
                string content = string.Format(this.layout.Format, dateTime, errorLevel, message) + "\n";
                this.logFile.Write(content);
                File.AppendAllText(path, content);
            }
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
