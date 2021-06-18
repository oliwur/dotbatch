using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotBatchLib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotBatch
{
    internal class ConsoleHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _lifetime;
        private readonly ILogger _logger = AppLogging.CreateLogger<ConsoleHostedService>();

        public ConsoleHostedService(IHostApplicationLifetime appLifetime)
        {
            _lifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical("critical message");
            _logger.LogError("error message");
            _logger.LogWarning("warning message");
            _logger.LogInformation("info message");
            _logger.LogDebug("debug message");
            _logger.LogTrace("trace message");
            
            _logger.LogTrace("first batch program");

            _logger.LogTrace("creating job");
            Job job = new Job();
            job.Name = "name of job";
            job.Steps = new List<Step>();

            _logger.LogTrace("creating first step");
            Step step1 = new Step();
            step1.Name = "first step";
            step1.ItemReader = new DummyItemReader();
            step1.ItemProcessor = new FuncItemProcessor<int, string>(x =>
            {
                _logger.LogTrace("in lambda func item processor 1");
                var result = "x1 = " + x;
                _logger.LogTrace(result);
                return result;
            });
            step1.ItemWriter = new ItemWriter();

            job.Steps.Add(step1);

            _logger.LogTrace("creating second step");
            Step step2 = new Step();
            step2.Name = "second step";
            step2.ItemReader = new DummyItemReader();
            step2.ItemProcessor = new FuncItemProcessor<int, string>(x =>
            {
                _logger.LogTrace("in lambda func item processor 2");
                var result = "x2 = " + x;
                _logger.LogTrace(result);
                return result;
            });
            step2.ItemWriter = new ItemWriter();

            job.Steps.Add(step2);

            JobInstance jobInst1 = job.CreateInstance();
            JobExecution jobExec1 = jobInst1.CreateExecution();

            _logger.LogTrace("job execution started");
            jobExec1.Run();
            _logger.LogTrace("job execution finished");

            _lifetime.StopApplication();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}