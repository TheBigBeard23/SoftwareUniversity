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
              .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
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
    }
}
