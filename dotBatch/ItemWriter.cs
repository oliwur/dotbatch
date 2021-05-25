using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class ItemWriter
    {
        private readonly ILogger _logger = AppLogging.CreateLogger<ItemReader>();
        
        public void write()
        {
            _logger.LogTrace("write");
        }
    }
}