
using SOLID.Core;
using SOLID.Core.Factories;
using SOLID.Core.IO;

namespace SOLID
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
