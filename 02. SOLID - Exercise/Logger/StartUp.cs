namespace Logger
{
    using Solid.Logger.Appenders;
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers.Contracts;
    using Solid.Logger.Loggers;

    class StartUp
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout);
            var logger = new Logger(fileAppender);
            
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info(" 3/26/2015 2:08:11 PM ", " User Pesho successfully registered.");
        }
    }
}
