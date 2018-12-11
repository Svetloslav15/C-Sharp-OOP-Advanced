namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;
    using System;
    using System.Linq;
    using FestivalManager.Core.IO;

    class Engine : IEngine
	{
	    private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController fControlcler, ISetController sController)
        {
            this.festivalCоntroller = fControlcler;
            this.setCоntroller = sController;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

		public void Run()
		{
			while (true)
			{
				string input = reader.ReadLine();

				if (input == "END")
                {
                    break;
                }

				try
				{
					string result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			string end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split();

            string command = tokens.First();
            string[] parameters = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var setovete = this.setCоntroller.PerformSets();
                return setovete;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { parameters });
            }
            catch (TargetInvocationException up)
            {
                throw up.InnerException;
            }

            return a;
        }
    }
}