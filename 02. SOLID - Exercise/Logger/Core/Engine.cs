namespace Solid.Logger.Core
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Core.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(inputArgs);
            }
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split("|");
                this.commandInterpreter.AddMessage(inputArgs);
                input = Console.ReadLine();
            }
            this.commandInterpreter.PrintInfo();
        }
    }
}
