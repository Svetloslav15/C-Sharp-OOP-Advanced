namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    using System;
    using System.Linq;
    using FestivalManager.Core.IO;

    public class Engine : IEngine
	{
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        
        public Engine(IFestivalController fesC, ISetController setC)
        {
            this.setCоntroller = setC;
            this.festivalCоntroller = fesC;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(" ");

            string first = tokens.First();
            string[] second = tokens.Skip(1).ToArray();

            if (first == "LetsRock")
            {
                string sets = this.setCоntroller.PerformSets();
                return sets;
            }

            MethodInfo festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == first);
            string result = "";
            try
            {
                result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { second });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            return result;

        }
    }
}