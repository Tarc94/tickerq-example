using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataExample.Repositories.Comment.Interfaces;
using DataExample.Repositories.Post.Interfaces;
using DataExample.Repositories.User.Interfaces;
using Scheduler.Services.Comments.Interfaces;

namespace Scheduler.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository) 
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task EveryoneCommentOnEveryPostAsync()
        {
            var now = DateTime.UtcNow;

            var allUsers = await _userRepository.RetrieveAllAsync();
            var allPosts = await _postRepository.RetrieveAllAsync();

            var comments = new List<DataExample.Entities.Comments>();

            foreach (var user in allUsers) 
            {
                foreach (var post in allPosts)
                {
                    comments.Add(new DataExample.Entities.Comments()
                    {
                        Text = $"{user.Name} commented now at {now}",
                        CreatedAt = now,
                        UserId = user.Id,
                        PostId = post.Id
                    });
                }
            }

            await _commentRepository.CreateManyAsync(comments);
        }
    }
}
