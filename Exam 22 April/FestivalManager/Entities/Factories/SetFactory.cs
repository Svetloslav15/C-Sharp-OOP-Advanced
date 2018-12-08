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
            Type currType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            ISet set = (ConcertSet)Activator.CreateInstance(currType);

            return set;
		}
	}
}