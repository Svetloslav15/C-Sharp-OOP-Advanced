using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameClass, params string[] fieldsName)
    {
        Type type = Type.GetType(nameClass);

        Object hacker = Activator.CreateInstance(type);
        
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Class under investigation: {nameClass}");
        FieldInfo[] fieldInfos = type.GetFields((BindingFlags)60);
        foreach (var item in fieldInfos.Where(x => fieldsName.Contains(x.Name)))
        {
            result.AppendLine($"{item.Name} = {item.GetValue(hacker)}");
        }
        return result.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);

        StringBuilder result = new StringBuilder();
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] getters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] setters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        foreach (FieldInfo field in fieldInfos)
        {
            result.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo getMethod in getters.Where(x => x.Name.StartsWith("get")))
        {
            result.AppendLine($"{getMethod.Name} have to be public!");
        }
        foreach (MethodInfo setMethod in setters.Where(x => x.Name.StartsWith("set")))
        {
            result.AppendLine($"{setMethod.Name} have to be private!");
        }
        return result.ToString().TrimEnd();
    }
}