namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
			Performer performer = new Performer(name, age);

			return performer;
		}
	}
}