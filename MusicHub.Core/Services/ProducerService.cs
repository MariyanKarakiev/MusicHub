using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicHub.Core.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IMusicHubRepository repo;

        public ProducerService(IMusicHubRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<ProducerModel>> GetAll()
        {
            return await repo.AllReadonly<Producer>()
                .Select(p => new ProducerModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    Pseudonym = p.Pseudonym
                })
                .ToListAsync();
        }
        public async Task<ProducerModel> Get(int? id)
        {
            return await repo.AllReadonly<Producer>()
                .Where(p => p.Id == id)
                .Select(p => new ProducerModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    Pseudonym = p.Pseudonym
                })
                .FirstOrDefaultAsync();
        }
        public async Task Add(ProducerModel model)
        {
            var objectToAdd = new Producer()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Pseudonym = model.Pseudonym
            };

            await repo.AddAsync(objectToAdd);
            await repo.SaveChangesAsync();
        }

        public async Task Update(ProducerModel model)
        {
            var objectToUpdate = await repo.AllReadonly<Producer>()
                 .Where(objectToUpdate => objectToUpdate.Id == model.Id)
                 .FirstOrDefaultAsync();

            objectToUpdate.Name = model.Name;
            objectToUpdate.PhoneNumber = model.PhoneNumber;
            objectToUpdate.Pseudonym = model.Pseudonym;

            repo.Update(objectToUpdate);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var objectToDelete = await repo.AllReadonly<Producer>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            repo.Delete(objectToDelete);
            await repo.SaveChangesAsync();
        }
    }
}