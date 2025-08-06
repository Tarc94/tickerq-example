using System;
using System.Threading.Tasks;
using SchedulerEF.Repositories.JobExceptions.Interfaces;
using TickerQ.Utilities.Enums;
using TickerQ.Utilities.Interfaces;

namespace Scheduler
{
    public class ExceptionHandler : ITickerExceptionHandler
    {
        private readonly IJobExceptionRepository _jobExceptionRepository;

        public ExceptionHandler(IJobExceptionRepository jobExceptionRepository) 
        { 
            _jobExceptionRepository = jobExceptionRepository;
        }

        public async Task HandleCanceledExceptionAsync(Exception exception, Guid tickerId, TickerType tickerType)
        {
            var log = new SchedulerEF.Entities.JobExceptions()
            {
                TickerId = tickerId,
                TickerType = tickerType,
                ExceptionMessage = exception.Message,
                CreatedAt = DateTime.UtcNow
            };

            await _jobExceptionRepository.CreateAsync(log);
        }

        public async Task HandleExceptionAsync(Exception exception, Guid tickerId, TickerType tickerType)
        {
            var log = new SchedulerEF.Entities.JobExceptions()
            {
                TickerId = tickerId,
                TickerType = tickerType,
                ExceptionMessage = exception.Message,
                CreatedAt = DateTime.UtcNow
            };

            await _jobExceptionRepository.CreateAsync(log);
        }
    }
}
