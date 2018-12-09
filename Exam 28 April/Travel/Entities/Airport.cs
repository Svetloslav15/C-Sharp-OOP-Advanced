namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> takenBags;
		private List<IBag> notTakenBags;
		private List<ITrip> adventures;
		private List<IPassenger> people;

        public Airport()
        {
            this.takenBags = new List<IBag>();
            this.notTakenBags = new List<IBag>();
            this.adventures = new List<ITrip>();
            this.people = new List<IPassenger>();
        }
        public IReadOnlyCollection<IBag> CheckedInBags => this.notTakenBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.takenBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.people.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.adventures.AsReadOnly();

        public IPassenger GetPassenger(string username)
        {
            return this.people.FirstOrDefault(x => x.Username == username);
        }

        public ITrip GetTrip(string id)
        {
            return this.adventures.FirstOrDefault(x => x.Id == id);
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.people.Add(passenger);
        }

		public void AddTrip(ITrip trip)
        {
            this.adventures.Add(trip);
        }

        public void AddCheckedBag(IBag bag)
        {
            this.notTakenBags.Add(bag);
        }

		public void AddConfiscatedBag(IBag bag)
        {
            this.takenBags.Add(bag);
        }
	}
}