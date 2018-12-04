namespace DatabasePeople
{
    using System;

    public class Person
    {
        public int Id { get; private set; }
        public string Username { get; set; }

        public Person(string username)
        {
            Random random = new Random();
            this.Id = random.Next(1, 100000);
            this.Username = username;
        }
    }
}
