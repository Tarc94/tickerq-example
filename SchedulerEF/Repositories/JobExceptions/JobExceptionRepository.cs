using System.Threading.Tasks;
using SchedulerEF.Repositories.JobExceptions.Interfaces;

namespace SchedulerEF.Repositories.JobExceptions
{
    public class JobExceptionRepository : IJobExceptionRepository
    {
        private readonly SchedulerContext _dbContext;

        public JobExceptionRepository(SchedulerContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Entities.JobExceptions exception)
        {
            await _dbContext.JobExceptions.AddAsync(exception);
            await _dbContext.SaveChangesAsync();
        }
    }
}
