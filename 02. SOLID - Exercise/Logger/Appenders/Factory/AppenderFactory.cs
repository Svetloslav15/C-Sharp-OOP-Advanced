namespace Solid.Logger.Appenders.Factory
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers;
    using System;

    public class AppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            type = type.ToLower();

            switch (type)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new Exception("Invalid Appender type!");
            }
        }
    }
}
