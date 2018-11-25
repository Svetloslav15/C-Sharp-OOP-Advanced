namespace Solid.Logger.Appenders
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers;
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; private set; }

       

        public void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (this.ReportLevel <= errorLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, errorLevel, message));
            }
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesCount}";
        }
    }
}
