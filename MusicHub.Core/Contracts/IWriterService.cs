using MusicHub.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicHub.Core.Contracts
{
    public interface IWriterService : IMusicHubService<WriterModel>
    {
        Task<int> Count();
    }
}
