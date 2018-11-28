namespace _03.Stack
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Push":
                        int[] items = tokens.Skip(1)
                            .Select(int.Parse)
                            .ToArray();
                        stack.Push(items);break;
                    case "Pop":
                        if (stack.Size == 0)
                        {
                            Console.WriteLine("No elements");
                        }
                        else
                        {
                            stack.Pop();
                        }
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join("\n", stack));
            }
        }
    }
}
