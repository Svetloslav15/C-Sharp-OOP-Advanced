namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            IList<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);
            }

            int count = int.Parse(Console.ReadLine());
            int equal = 0;
            for (int i = 1; i < people.Count; i++)
            {         
                if (people[count - 1].CompareTo(people[i]) == 0)
                {
                    equal++;
                }
            }
            if (equal == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {people.Count - equal} {people.Count}");
            }
        }
    }
}
