using Microsoft.Extensions.DependencyInjection;
using Scheduler.Services.Comments;
using Scheduler.Services.Comments.Interfaces;
using Scheduler.Services.Posts;
using Scheduler.Services.Posts.Interfaces;
using Scheduler.Services.Users;
using Scheduler.Services.Users.Interfaces;

namespace Scheduler.Services
{
    public static class DependencyInjection
    {
        public static void AddScopedServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUserService, UserService>();
            collection.AddScoped<IPostService, PostService>();
            collection.AddScoped<ICommentService, CommentService>();
        }
    }
}
