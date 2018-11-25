namespace GenericSwapMethodIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            IList<Box<int>> list = new List<Box<int>>();
            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap<Box<int>>(list, tokens[0], tokens[1]);
            Print<Box<int>>(list);
        }
        public static void Print<T>(IList<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T x = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = x;
        }
    }
}