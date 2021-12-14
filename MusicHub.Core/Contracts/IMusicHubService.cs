using MusicHub.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicHub.Core.Contracts
{
    public interface IMusicHubService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int? id);
        Task Add(T model);
        Task Update(T model);
        Task Delete(int? id);
    }
}
