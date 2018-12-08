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
	    public IReader reader;
	    public IWriter writer;

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
            while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    string.Intern(input);

                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) // in case we run out of memory
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
            var chasti = input.Split(" ".ToCharArray().First());

            var purvoto = chasti.First();
            var parametri = chasti.Skip(1).ToArray();

            if (purvoto == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == purvoto);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { parametri });
            }
            catch (TargetInvocationException up)
            {
                throw up; // ha ha
            }

            return a;
        }
    }
}