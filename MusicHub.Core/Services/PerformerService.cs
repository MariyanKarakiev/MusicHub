using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHub.Core.Services
{
    public class PerformerService : IPerformerService
    {
        private readonly IMusicHubRepository repo;

        public PerformerService(IMusicHubRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<PerformerModel>> GetAll()
        {
            return await repo.AllReadonly<Performer>()
                .Select(p => new PerformerModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Pseudonym = p.Pseudonym,
                    Age = p.Age,
                    Country = p.Country,
                })
                .ToListAsync();
        }

        public async Task<PerformerModel> Get(int? id)
        {
            return await repo.AllReadonly<Performer>()
                .Where(p => p.Id == id)
                .Select(p => new PerformerModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Pseudonym = p.Pseudonym,
                    Age = p.Age,
                    Country = p.Country,
                })
                .FirstOrDefaultAsync();
        }

        public async Task Add(PerformerModel model)
        {
            var objectToAdd = new Performer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Pseudonym = model.Pseudonym,
                Age = model.Age,
                Country = model.Country,
            };

            await repo.AddAsync(objectToAdd);
            await repo.SaveChangesAsync();
        }

        public async Task Update(PerformerModel model)
        {
            var objectToUpdate = await repo.AllReadonly<Performer>()
                 .Where(objectToUpdate => objectToUpdate.Id == model.Id)
                 .FirstOrDefaultAsync();

            objectToUpdate.Id = model.Id;
            objectToUpdate.FirstName = model.FirstName;
            objectToUpdate.LastName = model.LastName;
            objectToUpdate.Pseudonym = model.Pseudonym;
            objectToUpdate.Age = model.Age;
            objectToUpdate.Country = model.Country;

            repo.Update(objectToUpdate);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var objectToDelete = await repo.AllReadonly<Performer>()
                .Where(p => p.Id == id)
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
