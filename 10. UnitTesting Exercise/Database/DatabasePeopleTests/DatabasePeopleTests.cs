namespace DatabasePeopleTests
{
    using NUnit.Framework;
    using DatabasePeople;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabasePeopleTests
    {
        private Database db;
        private Person[] people = new Person[]
        {
            new Person("Gosho"),
            new Person("Pesho")
        };
        
        [SetUp]
        public void SetUp()
        {
            this.db = new Database(people);
        }

        [Test]
        public void ConstructorShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => db = new Database(people));    
        }

        [Test]
        public void TestPeopleSize()
        {
            Assert.AreEqual(db.people.Count(), 2);
        }

        [Test]
        public void AddPersonCorrectly()
        {
            db.AddUser(new Person("Ivan"));
            db.AddUser(new Person("Stamat"));
            Assert.AreEqual(db.people.Count(), 4);
        }

        [Test]
        public void FindByUsernameCorrectly()
        {
            Assert.DoesNotThrow(() => db.FindByUsername("Pesho"));
        }

        [Test]
        public void FindByUsernameInvalidUsername()
        {
            Assert.Throws<ArgumentException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameInvalidUser()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Stamat"));
        }

        [Test]
        public void RemovePersonCorrectly()
        {
            db.AddUser(new Person("Ivan"));
            Person person = db.FindByUsername("Ivan");
            Assert.DoesNotThrow(() => db.RemoveUser(person));
        }

        [Test]
        public void FindByIdCorrect()
        {
            int id = db.FindByUsername("Pesho").Id;
            Assert.DoesNotThrow(() => db.FindById(id));
        }

        [Test]
        public void FindByIdInvalidId()
        {
            Assert.Throws<ArgumentException>(() => db.FindById(-1));
        }

        [Test]
        public void FindByIdInvalidUser()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(89232));
        }
    }
}
