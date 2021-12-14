using MusicHub.Infrastructure;
using MusicHub.Infrastructure.Commons;

namespace MusicHub.Core
{
    public class MusicHubRepository : Repository, IMusicHubRepository
    {
        public MusicHubRepository(MusicHubDbContext context)
        {
            this.Context = context;
        }
    }
}
