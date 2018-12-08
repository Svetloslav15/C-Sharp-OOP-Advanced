namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : ConcertSet
	{
		public Short(string name) 
			: base(name, new TimeSpan(0, 16, 0))
		{
		}
	}
}