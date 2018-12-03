namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {

        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);
            BlackBoxInteger instance = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            FieldInfo fieldInfo = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int value = int.Parse(tokens[1]);

                MethodInfo method = type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(instance, new object[] { value });
                Console.WriteLine(fieldInfo.GetValue(instance));
            }
        }
    }
}
