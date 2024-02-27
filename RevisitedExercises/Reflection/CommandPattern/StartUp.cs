using System;
using CommandPattern.Commands;
using CommandPattern.Core;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter(new CommandFactory());
            IEngine engine = new Engine(command);

            engine.Run();
        }
    }
}
