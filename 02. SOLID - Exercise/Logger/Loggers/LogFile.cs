namespace Solid.Logger.Loggers
{
    using Solid.Logger.Loggers.Contracts;
    using System;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}
