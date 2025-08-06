using System.Threading.Tasks;
using SchedulerEF.Entities;

namespace SchedulerEF.Repositories.JobExceptions.Interfaces
{
    public interface IJobExceptionRepository
    {
        Task CreateAsync(SchedulerEF.Entities.JobExceptions exception);
    }
}
