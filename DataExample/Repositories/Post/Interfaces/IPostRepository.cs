using DataExample.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataExample.Repositories.Post.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Posts>> RetrieveAllAsync();
        Task<Posts> RetrieveByIdAsync(int id);
        Task<Posts> CreateAsync(Posts entity);
        Task<List<Posts>> CreateManyAsync(List<Posts> entities);
        Task<Posts> UpdateAsync(Posts entity);
        Task<List<Posts>> UpdateManyAsync(List<Posts> entities);
        Task DeleteAsync(Posts entity);
        Task DeleteManyAsync(List<Posts> entities);
    }
}
