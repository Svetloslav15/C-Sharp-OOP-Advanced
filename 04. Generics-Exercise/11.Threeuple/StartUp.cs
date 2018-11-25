namespace _11.Threeuple
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (i == 0)
                {
                    string name = tokens[0] + " " + tokens[1];
                    string address = tokens[2];
                    string town = tokens[3];
                    Console.WriteLine(new Threeuple<string, string, string>(name, address, town));
                }
                else if (i == 1)
                {
                    string name = tokens[0];
                    int bear = int.Parse(tokens[1]);
                    bool drinkOrNot = tokens[2] == "drunk" ? true : false;
                    Console.WriteLine(new Threeuple<string, int, bool>(name, bear, drinkOrNot));
                }
                else if (i == 2)
                {
                    string item1 = tokens[0];
                    double item2 = double.Parse(tokens[1]);
                    string bankName = tokens[2];
                    Console.WriteLine(new Threeuple<string, double, string>(item1, item2, bankName));
                }
            }
        }
    }
}
