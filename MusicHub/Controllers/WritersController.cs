using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;

namespace MusicHubMaster.Controllers
{
    public class WritersController : Controller
    {
        public IWriterService _service;

        public WritersController(IWriterService service)
        {
            _service = service;
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

            var writer = await _service.Get(id);

            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pseudonym")] WriterModel writer)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(writer);
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _service.Get(id);

            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pseudonym")] WriterModel writer)
        {
            if (id != writer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(writer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.Id))
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
            return View(writer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _service.Get(id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
            var writer = _service.Get(id);
            return writer != null;
        }
    }
}
