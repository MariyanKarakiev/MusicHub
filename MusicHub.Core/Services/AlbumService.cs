using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHub.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IMusicHubRepository repo;

        public AlbumService(IMusicHubRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<AlbumModel>> GetAll()
        {
            return await repo.AllReadonly<Album>()
                .Select(a => new AlbumModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    ReleaseDate = a.ReleaseDate,
                    ProducerId = a.ProducerId,
                    Producer = a.Producer.Name
                })
                .ToListAsync();
        }

        public async Task<AlbumModel> Get(int? id)
        {
            return await repo.AllReadonly<Album>()
                .Where(a => a.Id == id)
                .Select(a => new AlbumModel()
                {
                    Id = a.Id,
                    Price = a.Price,
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerId = a.ProducerId,
                    Producer = a.Producer.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task Add(AlbumModel model)
        {
            var objectToAdd = new Album()
            {
                Name = model.Name,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                ProducerId = model.ProducerId
            };

            await repo.AddAsync(objectToAdd);
            await repo.SaveChangesAsync();
        }

        public async Task Update(AlbumModel model)
        {
            var objectToUpdate = await repo.AllReadonly<Album>()
                 .Where(objectToUpdate => objectToUpdate.Id == model.Id)
                 .FirstOrDefaultAsync();

            objectToUpdate.Name = model.Name;
            objectToUpdate.Price = model.Price;
            objectToUpdate.ReleaseDate = model.ReleaseDate;
            objectToUpdate.ProducerId = model.ProducerId;

            repo.Update(objectToUpdate);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var objectToDelete = await repo.AllReadonly<Album>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            repo.Delete(objectToDelete);
            await repo.SaveChangesAsync();
        }
        public async Task<int> Count()
        {
            return await repo.AllReadonly<Song>().CountAsync();
        }
    }
}
