using MicrosoftDependencyInjection.Contracts;

namespace MicrosoftDependencyInjection
{
    public class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Start()
        {
            logger.Log("Game Started");
        }
        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
