namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            IList<Person> list = new List<Person>();

            for (int i = 0; i < nums; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                list.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            Print(list, new NameComparer());
            Print(list, new AgeComparer());
        }
        static void Print<T>(IList<Person> people, T comparer)
            where T : IComparer<Person>
        {
            SortedSet<Person> set = new SortedSet<Person>(people, comparer);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
