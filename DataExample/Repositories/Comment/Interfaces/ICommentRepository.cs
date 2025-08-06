using DataExample.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataExample.Repositories.Comment.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> RetrieveAllAsync();
        Task<Comments> RetrieveByIdAsync(int id);
        Task<Comments> CreateAsync(Comments entity);
        Task<List<Comments>> CreateManyAsync(List<Comments> entities);
        Task<Comments> UpdateAsync(Comments entity);
        Task<List<Comments>> UpdateManyAsync(List<Comments> entities);
        Task DeleteAsync(Comments entity);
        Task DeleteManyAsync(List<Comments> entities);
    }
}
