using System.Collections.Generic;
using System.Threading.Tasks;
using DataExample.Entities;
using DataExample.Repositories.Comment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataExample.Repositories.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataExampleContext _dbContext;

        public CommentRepository(DataExampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comments>> RetrieveAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comments> RetrieveByIdAsync(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comments> CreateAsync(Comments entity)
        {
            await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Comments>> CreateManyAsync(List<Comments> entities)
        {
            await _dbContext.Comments.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Comments> UpdateAsync(Comments entity)
        {
            _dbContext.Comments.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Comments>> UpdateManyAsync(List<Comments> entities)
        {
            _dbContext.Comments.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(Comments entity)
        {
            _dbContext.Comments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteManyAsync(List<Comments> entities)
        {
            _dbContext.Comments.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
