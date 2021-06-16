using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class Job
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<Job>();

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Step> Steps { get; set; }

        public JobInstance CreateInstance()
        {
            _logger.LogTrace("create instance");
            return new JobInstance() {Job = this};
        }
    }
}