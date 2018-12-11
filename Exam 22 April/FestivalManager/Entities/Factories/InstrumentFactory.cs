namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string typeName)
		{
            Type type = Assembly.GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name == typeName);
            IInstrument set = (IInstrument)Activator.CreateInstance(type);
            return set;
        }
	}
}