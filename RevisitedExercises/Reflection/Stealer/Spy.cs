using System.Reflection;
using System.Text;

namespace Stealer
{
    public static class Spy
    {
        public static string StealFieldInfo(string className, params string[] fieldsName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            Type type = Type.GetType(className);

            Object classInstance = Activator.CreateInstance(type, new object[] { });

            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            foreach (FieldInfo field in fields.Where(f => fieldsName.Contains(f.Name)))
            {
                sb.Append($"{field.Name} = {field.GetValue(classInstance)}\n");
            }

            return sb.ToString();
        }

        public static string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            FieldInfo[] classFields = type.GetFields((BindingFlags)28);
            MethodInfo[] classPublicMethods = type.GetMethods((BindingFlags)20);
            MethodInfo[] classNonPublicMethods = type.GetMethods((BindingFlags)36);

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString();
        }

        public static string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {type}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
