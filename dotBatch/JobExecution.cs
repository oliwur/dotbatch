using System;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class JobExecution
    {
        private readonly ILogger _logger = AppLogging.CreateLogger<JobExecution>();
        public JobInstance Instance { get; set; }

        public void Run()
        {
            _logger.LogTrace("run");
            foreach (Step step in Instance.Job.Steps)
            {
                step.execute();
            }
        }
    }
}