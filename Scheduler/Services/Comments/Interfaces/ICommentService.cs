using System.Threading.Tasks;

namespace Scheduler.Services.Comments.Interfaces
{
    public interface ICommentService
    {
        Task EveryoneCommentOnEveryPostAsync();
    }
}
