using Microsoft.Extensions.Logging;

namespace dotBatchLib
{
    public class JobExecution
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<JobExecution>();
        public JobInstance Instance { get; set; }

        public void Run()
        {
            _logger.LogTrace("run");
            foreach (Step step in Instance.Job.Steps)
            {
                step.Execute();
            }
        }
    }
}