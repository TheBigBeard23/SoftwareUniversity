using Logger.Core;
using Logger.Core.Factories;
using Logger.Core.IO;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader consoleReader = new ConsoleReader();
            IReader fileReader = new FileReader("../../../input.txt");

            IEngine engine = new Engine(appenderFactory, layoutFactory, consoleReader);
            engine.Run();
        }
    }
}