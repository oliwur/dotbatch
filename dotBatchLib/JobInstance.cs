using Microsoft.Extensions.Logging;

namespace dotBatchLib
{
    public class JobInstance
    {
        private readonly ILogger _logger = LibLogging.CreateLogger<JobInstance>();

        public Job Job { get; set; }

        public JobExecution CreateExecution()
        {
            _logger.LogTrace("create execution");
            return new JobExecution() {Instance = this};
        }
    }
}