namespace Solid.Logger.Appenders
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System.IO;

    public class FileAppender : IAppender
    {
        private const string path = "../../../log.txt";
        private readonly ILayout layout;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
        }
        public void Append(string dateTime, string errorLevel, string message)
        {
            string content = string.Format(this.layout.Format, dateTime, errorLevel, message) + "\n";
            File.AppendAllText(path, content);
        }
    }
}
