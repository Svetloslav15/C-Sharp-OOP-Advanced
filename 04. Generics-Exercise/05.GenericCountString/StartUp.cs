namespace _05.GenericCountString
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            IList<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            string value = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Compare(value))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
