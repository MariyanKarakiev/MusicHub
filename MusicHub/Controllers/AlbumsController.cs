using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;
using MusicHub.Core.Services;

namespace MusicHubMaster.Controllers
{
    public class AlbumsController : Controller
    {
        public IAlbumService _service;
        public IProducerService _producerService;

        public AlbumsController(IAlbumService service, IProducerService producerService)
        {
            _service = service;
            _producerService = producerService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _service.Get(id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ProducerId"] = new SelectList(await _producerService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Price,ProducerId")] AlbumModel album)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(album);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProducerId"] = new SelectList(await _producerService.GetAll(), "Id", "Name", album.ProducerId);
            return View(album);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _service.Get(id);

            if (album == null)
            {
                return NotFound();
            }

            ViewData["ProducerId"] = new SelectList(await _producerService.GetAll(), "Id", "Name", album.ProducerId);
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Price,ProducerId")] AlbumModel album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (album is null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(album);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
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

            ViewData["ProducerId"] = new SelectList(await _service.GetAll(), "Id", "Name", album.ProducerId);
            return View(album);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _service.Get(id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
