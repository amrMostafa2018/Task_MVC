using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Task.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async System.Threading.Tasks.Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("CVManager.Request: {Name} {@Request}",
                requestName, request);
        }
    }
}
