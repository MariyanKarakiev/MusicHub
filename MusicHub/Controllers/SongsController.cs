using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;


namespace MusicHubMaster.Controllers
{
    public class SongsController : Controller
    {
        public ISongService _service;
        public IWriterService _writerService;
        public IAlbumService _albumService;

        public SongsController(ISongService service, IWriterService writerService, IAlbumService albumService)
        {
            _service = service;
            _writerService = writerService;
            _albumService = albumService;
        }


        public async Task<IActionResult> Index(string genre, string searchString)
        {
            var SearchModel = new SearchModel()
            {
                Genres = new SelectList(_service.GetAllGenre()),
                Songs = await _service.GetSearchResults(genre, searchString)
            };

            return View(SearchModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _service.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Genre"] = new SelectList(_service.GetAllGenre());
            ViewData["AlbumId"] = new SelectList(await _albumService.GetAll(), "Id", "Name");
            ViewData["WriterId"] = new SelectList(await _writerService.GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,ReleaseDate,Genre,AlbumId,WriterId,Price,PictureURL")] SongModel song)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(song);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AlbumId"] = new SelectList(await _albumService.GetAll(), "Id", "Name");
            ViewData["WriterId"] = new SelectList(await _writerService.GetAll(), "Id", "Name");

            return View(song);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _service.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            ViewData["Genre"] = new SelectList(_service.GetAllGenre());
            ViewData["AlbumId"] = new SelectList(await _albumService.GetAll(), "Id", "Name");
            ViewData["WriterId"] = new SelectList(await _writerService.GetAll(), "Id", "Name");
            return View(song);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Duration,ReleaseDate,Genre,AlbumId,WriterId,Price,PictureURL")] SongModel song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(song);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["Genre"] = new SelectList(_service.GetAllGenre());
            ViewData["AlbumId"] = new SelectList(await _albumService.GetAll(), "Id", "Name");
            ViewData["WriterId"] = new SelectList(await _writerService.GetAll(), "Id", "Name");
            return View(song);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _service.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _service.Get(id);
            await _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
