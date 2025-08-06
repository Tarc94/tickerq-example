using System.Threading.Tasks;

namespace Scheduler.Services.Posts.Interfaces
{
    public interface IPostService
    {
        Task CreatePostForUserAsync(DataExample.Entities.Users user);
    }
}
