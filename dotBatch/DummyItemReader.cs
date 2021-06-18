using System;
using dotBatchLib;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class DummyItemReader : AbstractItemReader
    {
        private readonly ILogger log = AppLogging.CreateLogger<DummyItemReader>();
        
        private int count;

        public override void Open()
        {
            log.LogTrace("open");
            count = 10;
        }
        public override Object ReadItem()
        {
            log.LogTrace("read item " + count);
            if (count == 0)
                return null;
            return count--;
        }

        public override bool HasNext()
        {
            return count > 0;
        }
    }
}