namespace GenericBoxofIntegers
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                Console.WriteLine(box);
            }
        }
    }
}
