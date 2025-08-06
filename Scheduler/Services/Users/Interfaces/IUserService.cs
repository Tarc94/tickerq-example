using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task BulkCreateUsersAsync(Dictionary<string, string> entries);
        Task<DataExample.Entities.Users> RetrieveUserByIdAsync(int id);
    }
}
