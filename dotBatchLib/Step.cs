using System;
using Microsoft.Extensions.Logging;

namespace dotBatchLib
{
    public class Step
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<Step>();
        
        public string Name { get; set; }

        public ITemReader ItemReader { get; set; }
        public ITemProcessor ItemProcessor { get; set; }
        public ItemWriter ItemWriter { get; set; }

        public void Execute()
        {
            _logger.LogTrace("execute");
            ItemReader.Open();
            while (ItemReader.HasNext())
            {
                Object o = ItemReader.ReadItem();
                ItemProcessor.Process(o);
            }
            ItemReader.Close();
            
            ItemWriter.Write();
        }
    }
}