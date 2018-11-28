using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                result.Add(nums[i]);
            }
            List<int> temp = new List<int>();
            for (int i = 1; i < nums.Length; i += 2)
            {
                temp.Add(nums[i]);
            }
            temp.Reverse();
            result.AddRange(temp);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
