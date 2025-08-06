using System.Collections.Generic;
using System.Threading.Tasks;
using DataExample.Entities;
using DataExample.Repositories.Post.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataExample.Repositories.Post
{
    public class PostRepository : IPostRepository
    {
        private readonly DataExampleContext _dbContext;

        public PostRepository(DataExampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Posts>> RetrieveAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Posts> RetrieveByIdAsync(int id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Posts> CreateAsync(Posts entity)
        {
            await _dbContext.Posts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Posts>> CreateManyAsync(List<Posts> entities)
        {
            await _dbContext.Posts.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Posts> UpdateAsync(Posts entity)
        {
            _dbContext.Posts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Posts>> UpdateManyAsync(List<Posts> entities)
        {
            _dbContext.Posts.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(Posts entity)
        {
            _dbContext.Posts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteManyAsync(List<Posts> entities)
        {
            _dbContext.Posts.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
