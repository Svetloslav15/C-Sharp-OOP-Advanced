namespace _05.ComparingObjects
{
    using System;
    
    public class Person : IComparable<Person>
    {
         public string Name { get; private set;}
         public int Age { get; private set; }
         public string Town { get; private set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public int CompareTo(Person person)
        {
           if (person.Age == this.Age && person.Name == this.Name && this.Town == person.Town)
           {
               return 0;
           }
           return 1;
        }
    }
}
