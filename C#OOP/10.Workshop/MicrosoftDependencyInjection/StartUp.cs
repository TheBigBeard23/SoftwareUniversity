using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicrosoftDependencyInjection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = ServiceConfigurator.ConfigureServices();

            Engine engine = serviceProvider.GetRequiredService<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
