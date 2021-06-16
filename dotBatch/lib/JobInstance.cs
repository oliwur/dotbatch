using Microsoft.Extensions.Logging;

namespace dotBatch
{
    public class JobInstance
    {
        private readonly ILogger _logger = AppLogging.CreateLogger<JobInstance>();
        
        public Job Job { get; set; }

        public JobExecution CreateExecution()
        {
            _logger.LogTrace("create execution");
            return new JobExecution() {Instance = this};
        }
    }
}