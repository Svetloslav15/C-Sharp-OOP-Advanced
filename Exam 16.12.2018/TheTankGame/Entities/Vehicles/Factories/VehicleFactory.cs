namespace TheTankGame.Entities.Vehicles.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Vehicles.Contracts;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle
            (string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == vehicleType);

            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type, model, weight, price, attack, defense, hitPoints, new VehicleAssembler());
            return vehicle;
        }
    }
}
