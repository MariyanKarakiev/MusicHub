using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicHub.Infrastructure.Enums;

namespace MusicHub.Core.Services
{
    public class SongService : ISongService
    {
        private readonly IMusicHubRepository repo;

        public SongService(IMusicHubRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<SongModel>> GetAll()
        {
            return await repo.AllReadonly<Song>()
                .Select(a => new SongModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    ReleaseDate = a.ReleaseDate,
                    Duration = a.Duration,
                    Genre = a.Genre,
                    AlbumId = a.AlbumId,
                    AlbumName = a.Album.Name,
                    PictureURL = a.PictureURL,
                    WriterName = a.Writer.Name,
                    WriterId = a.WriterId
                })
                .ToListAsync();
        }

        public async Task<SongModel> Get(int? id)
        {
            return await repo.AllReadonly<Song>()
                .Where(a => a.Id == id)
                .Select(a => new SongModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    ReleaseDate = a.ReleaseDate,
                    Duration = a.Duration,
                    Genre = a.Genre,
                    AlbumId = a.AlbumId,
                    AlbumName = a.Album.Name,
                    PictureURL = a.PictureURL,
                    WriterName = a.Writer.Name,
                    WriterId = a.WriterId
                })
                .FirstOrDefaultAsync();
        }

        public async Task Add(SongModel model)
        {
            var objectToAdd = new Song()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Duration = model.Duration,
                Genre = model.Genre,
                AlbumId = model.AlbumId,
                PictureURL = model.PictureURL,
                WriterId = model.WriterId
            };

            await repo.AddAsync(objectToAdd);
            await repo.SaveChangesAsync();
        }

        public async Task Update(SongModel model)
        {
            var objectToUpdate = await repo.AllReadonly<Song>()
                 .Where(objectToUpdate => objectToUpdate.Id == model.Id)
                 .FirstOrDefaultAsync();

            objectToUpdate.Name = model.Name;
            objectToUpdate.Price = model.Price;
            objectToUpdate.ReleaseDate = model.ReleaseDate;
            objectToUpdate.Duration = model.Duration;
            objectToUpdate.Genre = model.Genre;
            objectToUpdate.AlbumId = model.AlbumId;
            objectToUpdate.PictureURL = model.PictureURL;
            objectToUpdate.WriterId = model.WriterId;


            repo.Update(objectToUpdate);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var objectToDelete = await repo.AllReadonly<Song>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            repo.Delete(objectToDelete);
            await repo.SaveChangesAsync();
        }

        public List<string> GetAllGenre()
        {
            var genres = new List<string>();
            genres.AddRange(Enum.GetNames(typeof(Genre)));

            return genres;
        }

        public async Task<List<SongModel>> GetSearchResults(string genre, string searchString)
        {

            if (genre == null && searchString == null)
            {
                return await repo.AllReadonly<Song>()
               .Select(a => new SongModel()
               {
                   Id = a.Id,
                   Name = a.Name,
                   Price = a.Price,
                   ReleaseDate = a.ReleaseDate,
                   Duration = a.Duration,
                   Genre = a.Genre,
                   AlbumId = a.AlbumId,
                   AlbumName = a.Album.Name,
                   PictureURL = a.PictureURL,
                   WriterName = a.Writer.Name,
                   WriterId = a.WriterId
               })
               .ToListAsync();
            }

            else if (searchString == null)
            {

                return await repo.AllReadonly<Song>()
                         .Where(s => s.Genre == (Genre)Enum.Parse(typeof(Genre), genre))
                         .Select(a => new SongModel()
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Price = a.Price,
                             ReleaseDate = a.ReleaseDate,
                             Duration = a.Duration,
                             Genre = a.Genre,
                             AlbumId = a.AlbumId,
                             AlbumName = a.Album.Name,
                             PictureURL = a.PictureURL,
                             WriterName = a.Writer.Name,
                             WriterId = a.WriterId
                         })
                        .ToListAsync();
            }

            else if (genre == null)
            {
                return await repo.AllReadonly<Song>()
                        .Where(s => s.Name == searchString)
                        .Select(a => new SongModel()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Price = a.Price,
                            ReleaseDate = a.ReleaseDate,
                            Duration = a.Duration,
                            Genre = a.Genre,
                            AlbumId = a.AlbumId,
                            AlbumName = a.Album.Name,
                            PictureURL = a.PictureURL,
                            WriterName = a.Writer.Name,
                            WriterId = a.WriterId
                        })
                       .ToListAsync();
            }
            else
            {
                return await repo.AllReadonly<Song>()
                   .Where(s => s.Name == searchString && s.Genre == (Genre)Enum.Parse(typeof(Genre), genre))
                   .Select(a => new SongModel()
                   {
                       Id = a.Id,
                       Name = a.Name,
                       Price = a.Price,
                       ReleaseDate = a.ReleaseDate,
                       Duration = a.Duration,
                       Genre = a.Genre,
                       AlbumId = a.AlbumId,
                       AlbumName = a.Album.Name,
                       PictureURL = a.PictureURL,
                       WriterName = a.Writer.Name,
                       WriterId = a.WriterId
                   })
                  .ToListAsync();
            }
        }
        public async Task<int> Count()
        {
            return await repo.AllReadonly<Song>().CountAsync();
        }
    }
}
