namespace _06.GenericCountDouble
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            IList<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            double value = double.Parse(Console.ReadLine());
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