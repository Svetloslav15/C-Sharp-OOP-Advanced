using System;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static
        );

        foreach (var method in methods)
        {
            var attrs = method.GetCustomAttributes<SoftUniAttribute>();
            foreach (SoftUniAttribute item in attrs)
            {
                Console.WriteLine($"{method.Name} is written by {item.Name}");
            }
        }
    }
}