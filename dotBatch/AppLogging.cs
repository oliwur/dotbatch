using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class AppLogging
    {
        private static ILoggerFactory _factory;

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                // if (_factory == null)
                // {
                //     _factory = new LoggerFactory();
                // }

                return _factory;
            }
            set { _factory = value; }
        }

        public static ILogger CreateLogger<T>() => _factory.CreateLogger<T>();
    }
}