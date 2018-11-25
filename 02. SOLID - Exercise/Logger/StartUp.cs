namespace Logger
{
    using Solid.Logger.Core;
    using Solid.Logger.Core.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
