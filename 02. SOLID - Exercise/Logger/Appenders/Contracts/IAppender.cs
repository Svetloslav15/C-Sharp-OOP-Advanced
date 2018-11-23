namespace Solid.Logger.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, string errorLevel, string message);
    }
}