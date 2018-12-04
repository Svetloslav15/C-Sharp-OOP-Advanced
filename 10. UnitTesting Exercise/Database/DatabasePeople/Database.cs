namespace DatabasePeople
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Database
    {
        public IList<Person> people;

        public Database(params Person[] people)
        {
            this.people = new List<Person>();
            this.SetInitialElements(people);
        }

        private void SetInitialElements(IList<Person> people)
        {
            foreach (var person in people)
            {
                this.AddUser(person);
            }
        }
        public void AddUser(Person user)
        {
            if (this.people.Any(x => x.Username == user.Username) || this.people.Any(x => x.Id == user.Id))
            {
                throw new InvalidOperationException("Invalid input data!");
            }
            this.people.Add(user);
        }

        public void RemoveUser(Person user)
        {
            if (this.people.Contains(user))
            {
                this.people.Remove(user);
            }
            else
            {
                throw new InvalidOperationException("User doesn't exists!");
            }
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentException("Username cannot be null!");
            }
            username = username.ToLower();
            Person person = this.people.FirstOrDefault(x => x.Username.ToLower() == username);
            if (person == null)
            {
                throw new InvalidOperationException("User doesn't exists!");
            }
            return person;
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative!");
            }
            Person person = this.people.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                throw new InvalidOperationException("User doesn't exists!");
            }
            return person;
        }
    }
}
