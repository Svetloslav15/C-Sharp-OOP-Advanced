using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            IList<Box<string>> list = new List<Box<string>>();
            for (int i = 0; i < lines; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap<Box<string>>(list, tokens[0], tokens[1]);
            Print<Box<string>>(list);
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
