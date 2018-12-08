namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using System;
    using StorageMaster.Entities.Storage;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using StorageMaster;
    using StorageMaster.Entities.Vehicles;
    using StorageMaster.Entities.Products;

    [TestFixture]
    public class StorageTests
    {
        private Type storageType;
        [SetUp]
        public void SetUp()
        {
            storageType = this.GetType("Storage");
        }

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "AutomatedWarehouse",
                "DistributionCenter",
                "Warehouse",
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{currentType} doesn't exists!");
            }
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            var actualProps = storageType.GetProperties();

            var expected = new Dictionary<string, Type>();
            expected.Add("Capacity", typeof(int));
            expected.Add("Name", typeof(string));
            expected.Add("GarageSlots", typeof(int));
            expected.Add("Garage", typeof(IReadOnlyCollection<Vehicle>));
            expected.Add("Products", typeof(IReadOnlyCollection<Product>));
            expected.Add("IsFull", typeof(bool));

            foreach (var actualProp in actualProps)
            {
                Assert.IsTrue(expected.Any(x => x.Key == actualProp.Name &&
                actualProp.PropertyType == x.Value), $"{actualProp.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>();
            expectedMethods.Add(new Method(typeof(Vehicle), "GetVehicle", typeof(Product)));
            expectedMethods.Add(new Method(typeof(int), "SendVehicleTo"));
            expectedMethods.Add(new Method(typeof(int), "UnloadVehicle"));

            var getVehicleMethod = storageType.GetMethod("GetVehicle");
            var sendVehicleToMethod = storageType.GetMethod("SendVehicleTo");
            var unloadVehicleMethod = storageType.GetMethod("UnloadVehicle");

            var loadMethodExists = expectedMethods.Any(x => x.Name == getVehicleMethod.Name &&
            x.ReturnType == getVehicleMethod.ReturnType);
            var sendVehicleToMethodExists = expectedMethods.Any(x => x.Name == sendVehicleToMethod.Name &&
            x.ReturnType == sendVehicleToMethod.ReturnType);
            var unloadMethodExists = expectedMethods.Any(x => x.Name == unloadVehicleMethod.Name &&
           x.ReturnType == unloadVehicleMethod.ReturnType);

            Assert.IsTrue(loadMethodExists, $"Load method doesn't pass");
            Assert.IsTrue(sendVehicleToMethodExists, $"SendVehicleTo method doesn't pass");
            Assert.IsTrue(unloadMethodExists, $"Unload method doesn't pass");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var garageField = storageType.GetField("garage", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(garageField, Is.Not.Null, "Invalid field");

            var productsField = storageType.GetField("products", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(productsField, Is.Not.Null, "Invalid field");

            var publicFields = storageType.GetFields();
            Assert.AreEqual(publicFields.Length, 0, "You cannot have public fields!");
        }

        [Test]
        public void ValidateAbstractClass()
        {
            Assert.IsTrue(storageType.IsAbstract);
        }

        [Test]
        public void ValidateChildren()
        {
            var derivedTypes = new[]
            {
                GetType("AutomatedWarehouse"),
                GetType("DistributionCenter"),
                GetType("Warehouse")
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(storageType));
            }
        }

        [Test]
        public void ValidateConstructor()
        {
            var ctor = this.storageType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            Assert.IsNotNull(ctor);
            Assert.IsTrue(ctor.IsFamily);
        }

        private Type GetType(string type)
        {
            Type targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            return targetType;
        }
        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParameters = inputParams;
            }
            public string Name { get; set; }
            public Type ReturnType { get; set; }
            public Type[] InputParameters { get; set; }
        }

    }
}
