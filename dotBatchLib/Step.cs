using System;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class Step
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<Step>();
        
        public string Name { get; set; }

        public ItemReader ItemReader { get; set; }
        public ItemProcessor ItemProcessor { get; set; }
        public ItemWriter ItemWriter { get; set; }

        public void execute()
        {
            _logger.LogTrace("execute");
            ItemReader.Open();
            while (ItemReader.HasNext())
            {
                Object o = ItemReader.ReadItem();
                ItemProcessor.Process(o);
            }
            ItemReader.Close();
            
            ItemWriter.write();
        }
    }
}