using System;
using System.Threading.Tasks;
using DataExample.Repositories.Post.Interfaces;
using Scheduler.Services.Posts.Interfaces;

namespace Scheduler.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }

        public async Task CreatePostForUserAsync(DataExample.Entities.Users user)
        {
            var now = DateTime.UtcNow;

            var post = new DataExample.Entities.Posts()
            {
                Title = $"New Post for User {user.Id}",
                Content = $"This is my new post for {now}",
                CreatedAt = now,
                UserId = user.Id
            };

            await _postRepository.CreateAsync(post);
        }
    }
}
