using DependencyInjection.Contracts;
using DependencyInjection.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class Engine
    {
        private ILogger logger;

        [Inject]
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
