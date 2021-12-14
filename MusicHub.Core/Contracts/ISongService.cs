using MusicHub.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicHub.Core.Contracts
{
    public interface ISongService : IMusicHubService<SongModel>
    {
        Task<int> Count();
        List<string> GetAllGenre();
        Task<List<SongModel>> GetSearchResults(string genre, string searchWord);
    }
}
