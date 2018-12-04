namespace DatabaseTests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Database;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(Database);              
        }

        [Test]
        public void TestConstructor()
        {
            ConstructorInfo constructorInfo = type.GetConstructor(
                new Type[] { typeof(int[]) });

            Assert.That(constructorInfo, Is.Not.Null);
        }
        
        [Test]
        public void TestIntegersCapacity()
        {
            FieldInfo integers = type.GetField("integers", BindingFlags.Instance | BindingFlags.NonPublic);
            bool test = integers.FieldType.IsArray;
            Assert.AreEqual(test, true);

            Database database = new Database(Enumerable.Range(1, 3).ToArray());
            int expected = 3;
            Assert.AreEqual(expected, database.Size);
            database.Add(7);
            expected = 4;
            Assert.AreEqual(expected, database.Size);
        }

        [Test]
        public void CheckThrowExceptionWhileAdding()
        {
            Database db;
            Assert.Throws<InvalidOperationException>(() => db = new Database(Enumerable.Range(1, 16).ToArray()));
        }

        [Test]
        public void TestFetchCommand()
        {
            Database db = (Database)Activator.CreateInstance(type);
            db.Add(4);
            db.Add(5);
            db.Add(6);
            int[] arr = db.Fetch();

            Type arrType = arr.GetType();
            Assert.AreEqual(arrType.IsArray, true);
            string test = string.Join(" ", arr);
            Assert.AreEqual(string.Join(" ", arr), "4 5 6 0 0 0 0 0 0 0 0 0 0 0 0 0");
        }

        [Test]
        public void RemoveLastElement()
        {
            Database db = new Database(Enumerable.Range(1, 3).ToArray());
            int expected = 3;
            Assert.AreEqual(expected, db.Size);
            db.Remove();
            expected = 2;
            Assert.AreEqual(expected, db.Size);
        }

        [Test]
        public void RemoveShouldThrowException()
        {
            Database db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void RemoveFromFullCollectionAndThenAdd()
        {
            Database db = new Database(Enumerable.Range(1, 16).ToArray());
            db.Remove();
            Assert.AreEqual(db.Size, 15);
            db.Add(4);
            Assert.AreEqual(db.Size, 16);
        }
        
        [Test]
        public void ModifyAndFetch()
        {
            Database db = new Database(Enumerable.Range(1, 5).ToArray());
            db.Add(4);
            db.Add(7);
            db.Remove();
            db.Remove();
            db.Add(8);
            int expectedSize = 6;
            Assert.AreEqual(db.Size, expectedSize);
        }
    }
}