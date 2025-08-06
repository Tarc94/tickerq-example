using System;
using System.Threading.Tasks;
using Scheduler.Services.Posts.Interfaces;
using Scheduler.Services.Users.Interfaces;
using TickerQ.Utilities.Base;

namespace Scheduler.Jobs
{
    public class PostSchedulerJob
    {
        public const string JobName = "Create a new post";
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostSchedulerJob(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        // Runs at 30 minutes past the hour, between 8am and 8:59pm, Monday through Friday
        [TickerFunction(functionName: JobName, cronExpression: "30 8-20 * * 1-5")]
        public async Task PostSchedulerJobAsync()
        {
            int userId = 35;

            var user = await _userService.RetrieveUserByIdAsync(userId) ?? throw new Exception($"User with id {userId} was not found");
            
            await _postService.CreatePostForUserAsync(user);
        }
    }
}
