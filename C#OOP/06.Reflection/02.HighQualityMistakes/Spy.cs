using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string typeName, params string[] fieldsNames)
        {
            var classType = Type.GetType($"Stealer.{typeName}");
            var fields = classType
              .GetFields(BindingFlags.Instance |
                         BindingFlags.Static |
                         BindingFlags.Public |
                         BindingFlags.NonPublic)

              .Where(x => fieldsNames.Contains(x.Name));

            var classInstance = Activator.CreateInstance(classType);
            var sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {classType}");

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            var classType = Type.GetType($"Stealer.{className}");

            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance |
                           BindingFlags.Static |
                           BindingFlags.Public |
                           BindingFlags.NonPublic);

            MethodInfo[] classPublicMethods = classType
                .GetMethods(BindingFlags.Instance |
                            BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = classType
                .GetMethods(BindingFlags.Instance |
                            BindingFlags.NonPublic);

            var sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} has to be public!");
            }
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} has to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
