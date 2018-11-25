namespace _10.Tuple
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
                    Tuple<string, string> tuple = new Tuple<string, string>(name, address);
                    Console.WriteLine(tuple);
                }
                else if (i == 1)
                {
                    string name = tokens[0];
                    int bear = int.Parse(tokens[1]);
                    Tuple<string, int> tuple = new Tuple<string, int>(name, bear);
                    Console.WriteLine(tuple);
                }
                else if (i == 2)
                {
                    int item1 = int.Parse(tokens[0]);
                    double item2 = double.Parse(tokens[1]);
                    Tuple<int, double> tuple = new Tuple<int, double>(item1, item2);
                    Console.WriteLine(tuple);
                }
            }
        }
    }
}
