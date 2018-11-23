namespace Solid.Logger.Appenders
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime, string errorLevel, string message)
        {
            Console.WriteLine(string.Format(this.Layout.Format, dateTime, errorLevel, message));
        }

        public void Append()
        {
            throw new NotImplementedException();
        }
    }
}
