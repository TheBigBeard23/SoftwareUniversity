using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactoy
    {
        public ICommand CreateCommand(string commandType)
        {
            var type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(commandType));

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }

            var instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
