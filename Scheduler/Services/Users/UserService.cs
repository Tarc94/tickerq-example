using System.Collections.Generic;
using System.Threading.Tasks;
using DataExample.Entities;
using DataExample.Repositories.User.Interfaces;
using Scheduler.Services.Users.Interfaces;

namespace Scheduler.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public async Task BulkCreateUsersAsync(Dictionary<string, string> entries)
        {
            var users = new List<DataExample.Entities.Users>();

            foreach (var entry in entries) 
            {
                users.Add(new DataExample.Entities.Users()
                {
                    Name = entry.Key,
                    Email = entry.Value
                });
            }

            await _userRepository.CreateManyAsync(users);
        }

        public async Task<DataExample.Entities.Users> RetrieveUserByIdAsync(int id)
        {
            return await _userRepository.RetrieveByIdAsync(id);
        }
    }
}
