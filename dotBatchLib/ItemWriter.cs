using Microsoft.Extensions.Logging;

namespace dotBatchLib
{
    public class ItemWriter
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<ITemReader>();
        
        public void Write()
        {
            _logger.LogTrace("write");
        }
    }
}