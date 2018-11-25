using System;

namespace GenericBoxofString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string value = Console.ReadLine();
                Box<string> box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}
