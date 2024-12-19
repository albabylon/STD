using System.Threading;

namespace InterfacesDIExample
{
    public class Worker1 : IWorker
    {
        ILogger logger { get; }
        public Worker1(ILogger logger)
        {
            this.logger = logger;
        }
        public void Work()
        {
            logger.Event("Worker 1 начал работу");
            Thread.Sleep(3000);
            logger.Event("Worker 1 закончил работу");
        }
    }

    public class Worker2 : IWorker
    {
        ILogger logger { get; }
        public Worker2(ILogger logger)
        {
            this.logger = logger;
        }
        public void Work()
        {
            logger.Event("Worker 2 начал работу");
            Thread.Sleep(3000);
            logger.Event("Worker 2 закончил работу");
        }
    }

    public class Worker3 : IWorker
    {
        ILogger logger { get; }
        public Worker3(ILogger logger)
        {
            this.logger = logger;
        }
        public void Work()
        {
            logger.Event("Worker 3 начал работу");
            Thread.Sleep(3000);
            logger.Event("Worker 3 закончил работу");
        }
    }
}
