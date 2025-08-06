using System.Threading.Tasks;
using TickerQ.Utilities.Base;
using Scheduler.Services.Comments.Interfaces;

namespace Scheduler.Jobs
{
    public class CommentSchedulerJob
    {
        public const string JobName = "Schedule comments on all posts";
        private readonly ICommentService _commentService;

        public CommentSchedulerJob(ICommentService commentService) 
        {
            _commentService = commentService;
        }

        // Runs every hour, between 8am and 8:59pm, Monday through Friday
        [TickerFunction(functionName: JobName, cronExpression: "0 8-20 * * 1-5")]
        public async Task CommentSchedulerJobAsync()
        {
            await _commentService.EveryoneCommentOnEveryPostAsync();
        }
    }
}
