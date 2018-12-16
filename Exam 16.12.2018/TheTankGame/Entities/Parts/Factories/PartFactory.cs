namespace TheTankGame.Entities.Parts.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == partType + "Part");

            IPart vehicle = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);
            return vehicle;
        }
    }
}
