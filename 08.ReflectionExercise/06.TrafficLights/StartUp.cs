namespace _06.TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<TrafficLight> trafficLights = new List<TrafficLight>();
            for(int index = 0; index < input.Length; index++)
            {
                Type type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == "TrafficLight");

                TrafficLight instance = (TrafficLight)Activator.CreateInstance(type, new object[] { input[index] });
               
                trafficLights.Add(instance);
            }
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                string result = "";
                foreach (var item in trafficLights)
                {
                    item.Update();
                    result += item.signal + " ";
                }
                Console.WriteLine(result.TrimEnd());
            }
        }
    }
}
