namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using System;
    using StorageMaster.Core;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;

    [TestFixture]
    public class StorageMasterTests
    {
        private Type storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = this.GetType("StorageMaster");
        }

        [Test]
        public void ValidateAddProductMethod()
        {
            var addProductMethod = storageMaster.GetMethod("AddProduct");
            var instance = Activator.CreateInstance(storageMaster);
            var result = addProductMethod.Invoke(instance, new object[] { "SolidStateDrive", 25.6 });

            Assert.AreEqual(result, "Added SolidStateDrive to pool");

            var poolFields = (IDictionary<string, Stack<Product>>)storageMaster
                .GetField("productsPool", (BindingFlags)62)
                .GetValue(instance);

            Assert.AreEqual(poolFields["SolidStateDrive"].Count, 1);
        }

        [Test]
        public void RegisterStorageMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);
            var result = registerStorageMethod.Invoke(instance, new object[] { "DistributionCenter", "Gosho" });
            Assert.AreEqual(result, "Registered Gosho");

            var storageField = (IDictionary<string, Storage>)storageMaster
                .GetField("storageRegistry", (BindingFlags)62)
                .GetValue(instance);

            Assert.That(storageField["Gosho"].Name, Is.EqualTo("Gosho"));
        }
        
        [Test]
        public void SendVehicleTo()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            string storageName = "DistributionCenter";
            string name = "Gosho";
            string storageName2 = "DistributionCenter";
            string name2 = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { storageName, name });
            registerStorageMethod.Invoke(instance, new object[] { storageName2, name2 });

            var actualResult = storageMaster.GetMethod("SendVehicleTo")
                .Invoke(instance, new object[] { name, 0, name2});
            var expectedResult =  $"Sent Van to Pesho (slot 3)";

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void SelectVehicle()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var selectVehicleMethod = storageMaster.GetMethod("SelectVehicle");
            var instance = Activator.CreateInstance(storageMaster);
            string storageName = "DistributionCenter";
            string name = "Gosho";

            registerStorageMethod.Invoke(instance, new object[] { storageName, name });

            var actualResult = storageMaster.GetMethod("SelectVehicle")
                .Invoke(instance, new object[] { name, 1 });
            var expectedResult = $"Selected Van";

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void UnloadVehicle()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var unloadVehicleMethod = storageMaster.GetMethod("UnloadVehicle");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var instance = Activator.CreateInstance(storageMaster);
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            string storageName = "DistributionCenter";
            string name = "Gosho";

            IEnumerable<string> seq = new List<string>()
            {
                "Gpu", "HardDrive", "Ram", "SolidStateDrive"
            };
            registerStorageMethod.Invoke(instance, new object[] { storageName, name });
            storageMaster.GetMethod("SelectVehicle").Invoke(instance, new object[] { name, 1 });
            addProductMethod.Invoke(instance, new object[] { "Gpu", 87 });
            addProductMethod.Invoke(instance, new object[] { "HardDrive", 258 });
            addProductMethod.Invoke(instance, new object[] { "Ram", 30 });
            addProductMethod.Invoke(instance, new object[] { "SolidStateDrive", 40 });

            var actualResult = unloadVehicleMethod.Invoke(instance, new object[] { "Gosho", 2 });
            var expected = "Unloaded 0/0 products at Gosho";
            Assert.AreEqual(actualResult, expected);
        }

        [Test]
        public void LoadVehicle()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var instance = Activator.CreateInstance(storageMaster);
            var addProductMethod = storageMaster.GetMethod("AddProduct");
            string storageName = "DistributionCenter";
            string name = "Gosho";

            IEnumerable<string> seq = new List<string>()
            {
                "Gpu", "HardDrive", "Ram", "SolidStateDrive"
            };
            registerStorageMethod.Invoke(instance, new object[] { storageName, name });
            storageMaster.GetMethod("SelectVehicle").Invoke(instance, new object[] { name, 1 });
            addProductMethod.Invoke(instance, new object[] { "Gpu", 87 });
            addProductMethod.Invoke(instance, new object[] { "HardDrive", 258 });
            addProductMethod.Invoke(instance, new object[] { "Ram", 30 });
            addProductMethod.Invoke(instance, new object[] { "SolidStateDrive", 40 });

            var actualResult = loadVehicleMethod.Invoke(instance, new object[] { seq });
            var expected = "Loaded 4/4 products into Van";
            Assert.AreEqual(actualResult, expected);
        }
        
        [Test]
        public void GetStorageStatus()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var getStatusMethod = storageMaster.GetMethod("GetStorageStatus");
            var instance = Activator.CreateInstance(storageMaster);
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            string storageName = "DistributionCenter";
            string name = "Gosho";

            IEnumerable<string> seq = new List<string>()
            {
                "Gpu", "HardDrive", "Ram", "SolidStateDrive"
            };
            registerStorageMethod.Invoke(instance, new object[] { storageName, name });
            storageMaster.GetMethod("SelectVehicle").Invoke(instance, new object[] { name, 1 });
            addProductMethod.Invoke(instance, new object[] { "Gpu", 87 });
            addProductMethod.Invoke(instance, new object[] { "HardDrive", 258 });
            addProductMethod.Invoke(instance, new object[] { "Ram", 30 });
            addProductMethod.Invoke(instance, new object[] { "SolidStateDrive", 40 });

            var actualResult = getStatusMethod.Invoke(instance, new object[] { name });
            var expected = "Stock (0/2): []\r\nGarage: [Van|Van|Van|empty|empty]";
            Assert.AreEqual(actualResult, expected);
        }

        [Test]
        public void GetSummary()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var getSummaryMethod = storageMaster.GetMethod("GetSummary");
            var instance = Activator.CreateInstance(storageMaster);
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            string storageName = "DistributionCenter";
            string name = "Gosho";

            IEnumerable<string> seq = new List<string>()
            {
                "Gpu", "HardDrive", "Ram", "SolidStateDrive"
            };
            registerStorageMethod.Invoke(instance, new object[] { storageName, name });
            storageMaster.GetMethod("SelectVehicle").Invoke(instance, new object[] { name, 1 });
            addProductMethod.Invoke(instance, new object[] { "Gpu", 87 });
            addProductMethod.Invoke(instance, new object[] { "HardDrive", 258 });
            addProductMethod.Invoke(instance, new object[] { "Ram", 30 });
            addProductMethod.Invoke(instance, new object[] { "SolidStateDrive", 40 });

            var actualResult = getSummaryMethod.Invoke(instance, new object[] { });
            var expected = "Gosho:\r\nStorage worth: $0.00";
            Assert.AreEqual(actualResult, expected);
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
