using System.Collections.Generic;
using DataExample.Repositories.User.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataExample.Entities;
using System.Threading.Tasks;

namespace DataExample.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DataExampleContext _dbContext;

        public UserRepository(DataExampleContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<List<Users>> RetrieveAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<Users> RetrieveByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Users> CreateAsync(Users entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Users>> CreateManyAsync(List<Users> entities)
        {
            await _dbContext.Users.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<Users> UpdateAsync(Users entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Users>> UpdateManyAsync(List<Users> entities)
        {
            _dbContext.Users.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(Users entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteManyAsync(List<Users> entities)
        {
            _dbContext.Users.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
