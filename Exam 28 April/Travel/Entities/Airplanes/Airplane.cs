namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public int Seats { get; private set; }
        public int BaggageCompartments { get; private set; }        
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
        public bool IsOverbooked => this.passengers.Count > this.Seats;

        protected Airplane(int seats, int baggage)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggage;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }
        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }
        public IPassenger RemovePassenger(int index)
        {
            IPassenger passenger = this.passengers[index];
            this.passengers.RemoveAt(index);

            return passenger;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count >= this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            this.baggageCompartment.Add(bag);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            List<IBag> bags = this.baggageCompartment.Where(x => x.Owner == passenger).ToList();
            foreach (var bag in bags)
            {
                this.baggageCompartment.Remove(bag);
            }
            return bags;
        }
    }
}