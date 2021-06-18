using Microsoft.Extensions.Logging;

namespace dotBatchLib
{
    public static class LibLogging
    {
        private static ILoggerFactory _factory;

        public static ILoggerFactory LoggerFactory
        {
            get =>
                // if (_factory == null)
                // {
                //     _factory = new LoggerFactory();
                // }
                _factory;
            set => _factory = value;
        }

        public static ILogger CreateLogger<T>() => _factory.CreateLogger<T>();
    }
}