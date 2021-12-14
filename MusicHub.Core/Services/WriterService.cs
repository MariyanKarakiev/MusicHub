using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHub.Core.Services
{
    public class WriterService : IWriterService
    {
        private readonly IMusicHubRepository repo;

        public WriterService(IMusicHubRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<WriterModel>> GetAll()
        {
            return await repo.AllReadonly<Writer>()
                .Select(e => new WriterModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Pseudonym = e.Pseudonym
                })
                .ToListAsync();
        }
        public async Task<WriterModel> Get(int? id)
        {
            return await repo.AllReadonly<Writer>()
                .Where(w => w.Id == id)
                .Select(e => new WriterModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Pseudonym = e.Pseudonym
                })
                .FirstOrDefaultAsync();
        }
        public async Task Add(WriterModel model)
        {
            var writer = new Writer()
            {
                Name = model.Name,
                Pseudonym = model.Pseudonym
            };

            await repo.AddAsync(writer);
            await repo.SaveChangesAsync();
        }

        public async Task Update(WriterModel model)
        {
            var writerToUpdate = await repo.AllReadonly<Writer>()
                 .Where(w => w.Id == model.Id)
                 .FirstOrDefaultAsync();

            writerToUpdate.Name = model.Name;
            writerToUpdate.Pseudonym = model.Pseudonym;

            repo.Update(writerToUpdate);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var writerToDelete = await repo.AllReadonly<Writer>()
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            repo.Delete(writerToDelete);
            await repo.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await repo.AllReadonly<Song>().CountAsync();
        }
    }
}