using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;

namespace MusicHubMaster.Controllers
{
    public class ProducersController : Controller
    {
        public IProducerService _service;

        public ProducersController(IProducerService service)
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

            var producer = await _service.Get(id);

            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pseudonym,PhoneNumber")] ProducerModel producer)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _service.Get(id);

            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pseudonym,PhoneNumber")] ProducerModel producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(producer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists(producer.Id))
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
            return View(producer);
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

        private bool ProducerExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
