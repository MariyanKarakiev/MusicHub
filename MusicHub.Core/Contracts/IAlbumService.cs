using MusicHub.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicHub.Core.Contracts
{
    public interface IAlbumService : IMusicHubService<AlbumModel>
    {
        Task<int> Count();
    }
}
