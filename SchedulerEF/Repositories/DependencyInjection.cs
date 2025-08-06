using Microsoft.Extensions.DependencyInjection;
using SchedulerEF.Repositories.JobExceptions;
using SchedulerEF.Repositories.JobExceptions.Interfaces;

namespace SchedulerEF.Repositories
{
    public static class DependencyInjection
    {
        public static void AddTickerRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IJobExceptionRepository, JobExceptionRepository>();
        }
    }
}
