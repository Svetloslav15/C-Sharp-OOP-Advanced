namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class VehiclesTests
    {
        private Type vehicleType;
        [SetUp]
        public void SetUp()
        {
            vehicleType = this.GetType("Vehicle");
        }

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
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
            var actualProps = vehicleType.GetProperties();

            var expected = new Dictionary<string, Type>();
            expected.Add("Capacity", typeof(int));
            expected.Add("Trunk", typeof(IReadOnlyCollection<Product>));
            expected.Add("IsFull", typeof(bool));
            expected.Add("IsEmpty", typeof(bool));

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
            expectedMethods.Add(new Method(typeof(void), "LoadProduct", typeof(Product)));
            expectedMethods.Add(new Method(typeof(Product), "Unload"));

            var loadMethod = vehicleType.GetMethod("LoadProduct");
            var unloadMethod = vehicleType.GetMethod("Unload");

            var loadMethodExists = expectedMethods.Any(x => x.Name == loadMethod.Name &&
            x.ReturnType == loadMethod.ReturnType);
            var unloadMethodExists = expectedMethods.Any(x => x.Name == unloadMethod.Name &&
            x.ReturnType == unloadMethod.ReturnType);

            Assert.IsTrue(loadMethodExists, $"Load method doesn't pass");
            Assert.IsTrue(unloadMethodExists, $"Unload method doesn't pass");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = vehicleType.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(trunkField, Is.Not.Null, "Invalid field");

            var publicFields = vehicleType.GetFields();
            Assert.AreEqual(publicFields.Length, 0, "You cannot have public fields!");
        }

        [Test]
        public void ValidateAbstractClass()
        {
            Assert.IsTrue(vehicleType.IsAbstract);
        }

        [Test]
        public void ValidateChildren()
        {
            var derivedTypes = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van")
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(vehicleType));
            }
        }

        [Test]
        public void ValidateConstructor()
        {
            var ctor = this.vehicleType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            Assert.IsNotNull(ctor);
            Assert.IsTrue(ctor.IsFamily);

            var ctorParams = ctor.GetParameters();
            Assert.That(ctorParams[0].ParameterType, Is.EqualTo(typeof(int)));
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