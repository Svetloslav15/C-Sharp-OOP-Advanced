namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ProductsTests
    {
        private Type productType;

        [SetUp]
        public void StartUp()
        {
            productType = typeof(Product);
        }

        [Test]
        public void ValidateAllProducts()
        {
            var types = new[]
            {
                "Gpu", "HardDrive", "Ram", "SolidStateDrive"
            };

            foreach (var type in types)
            {
                var currType = GetType(type);
                Assert.IsNotNull(currType);
            }
        }

        [Test]
        public void ValidateProductProperties()
        {
            var actualProps = productType.GetProperties();
            var expected = new Dictionary<string, Type>();
            expected.Add("Price", typeof(double));
            expected.Add("Weight", typeof(double));

            foreach (var actualProp in actualProps)
            {
                Assert.IsTrue(expected.Any(x => x.Key == actualProp.Name &&
                actualProp.PropertyType == x.Value), $"{actualProp.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateAbstractClass()
        {
            Assert.IsTrue(productType.IsAbstract);
        }

        [Test]
        public void ValidateChildren()
        {
            var derivedTypes = new[]
            {
                this.GetType("Gpu"),
                this.GetType("HardDrive"),
                this.GetType("Ram"),
                this.GetType("SolidStateDrive"),
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(productType));
            }
        }

        [Test]
        public void ValidateConstructor()
        {
            var ctor = this.productType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            Assert.IsNotNull(ctor);
            Assert.IsTrue(ctor.IsFamily);

            var ctorParams = ctor.GetParameters();
            Assert.That(ctorParams[0].ParameterType, Is.EqualTo(typeof(double)));
        }

        private Type GetType(string type)
        {
            Type targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            return targetType;
        }
    }
}
