namespace _07.CustomList
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<string> customList = new CustomList<string>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Add": customList.Add(tokens[1]);break;
                    case "Remove": customList.Remove(int.Parse(tokens[1]));break;
                    case "Contains": Console.WriteLine(customList.Contains(tokens[1]));break;
                    case "Swap": customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));break;
                    case "Greater": Console.WriteLine(customList.CountGreaterThan(tokens[1]));break;
                    case "Max": Console.WriteLine(customList.Max());break;
                    case "Min": Console.WriteLine(customList.Min());break;
                    case "Print": customList.Print();break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
