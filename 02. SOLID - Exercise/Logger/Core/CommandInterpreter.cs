namespace Solid.Logger.Core
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Appenders.Factory;
    using Solid.Logger.Core.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Layouts.Factory;
    using Solid.Logger.Loggers;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private AppenderFactory appenderFactory;
        private LayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void PrintInfo()
        {
            Console.WriteLine("Logger Info");
            foreach (var item in this.appenders)
            {
                Console.WriteLine(item);
            }
        }
        public void AddAppender(string[] args)
        {
            string appendedType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.Info;
            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appendedType, layout);
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0], true);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
