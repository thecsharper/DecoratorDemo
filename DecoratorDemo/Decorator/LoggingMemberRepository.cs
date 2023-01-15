using DecoratorDemo.Decorated;
using Microsoft.Extensions.Logging;

namespace DecoratorDemo.Decorator
{
    public class LoggingMemberRepository : IMemberRepository
    {
        private readonly IMemberRepository _repository;
        private readonly ILogger _logger;

        public LoggingMemberRepository(
            IMemberRepository repository,
            ILogger<LoggingMemberRepository> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IdMapping GetById(int id)
        {
            _logger.LogInformation($"Getting by Id: {id}");
            return _repository.GetById(id);
        }
    }
}
