 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] allFields = type.GetFields((BindingFlags)60);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                Func<FieldInfo, bool> condition = x => x.IsPrivate;

                if (input == "public")
                {
                    condition = x => x.IsPublic;
                }
                else if (input == "protected")
                {
                    condition = x => x.IsFamily;
                }
                else if (input == "all")
                {
                    condition = x => !x.IsStatic;
                }
                foreach (var item in allFields.Where(condition))
                {
                    Console.WriteLine($"{item.Attributes.ToString().ToLower().Replace("family", "protected")} {item.FieldType.Name} {item.Name}");
                }
            }
        }
    }
}
