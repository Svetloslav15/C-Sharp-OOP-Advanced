namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters = inputParameters.Skip(1).ToList();

            Type currentType = this.tankManager.GetType();
            MethodInfo currentMethod = currentType.GetMethods()
                .First(x => x.Name.Contains(command));
            
            var result = string.Empty;
            if (currentMethod != null)
            {
                result = currentMethod.Invoke(this.tankManager, new object[] { inputParameters }).ToString();
            }

            return result;
        }
    }
}