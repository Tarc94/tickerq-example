using DataExample.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataExample.Repositories.User.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> RetrieveAllAsync();
        Task<Users> RetrieveByIdAsync(int id);
        Task<Users> CreateAsync(Users entity);
        Task<List<Users>> CreateManyAsync(List<Users> entities);
        Task<Users> UpdateAsync(Users entity);
        Task<List<Users>> UpdateManyAsync(List<Users> entities);
        Task DeleteAsync(Users entity);
        Task DeleteManyAsync(List<Users> entities);
    }
}
