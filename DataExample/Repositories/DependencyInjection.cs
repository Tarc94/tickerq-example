using DataExample.Repositories.Comment;
using DataExample.Repositories.Comment.Interfaces;
using DataExample.Repositories.Post;
using DataExample.Repositories.Post.Interfaces;
using DataExample.Repositories.User;
using DataExample.Repositories.User.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataExample.Repositories
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IPostRepository, PostRepository>();
            collection.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
