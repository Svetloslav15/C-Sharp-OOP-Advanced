namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;
    using System;
    using System.Linq;
    using System.Reflection;
    
    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type currType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            ISet set = (ISet)Activator.CreateInstance(currType, name);

            return set;
		}
	}
}