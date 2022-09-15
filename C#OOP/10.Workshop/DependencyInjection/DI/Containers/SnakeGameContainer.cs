using DependencyInjection.Contracts;
using DependencyInjection.Loggers;

namespace DependencyInjection.DI.Containers
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            CreateMapping<ILogger, ConsoleLogger>();
        }
    }
}
