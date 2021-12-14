using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHub.Core.Contracts;
using MusicHub.Core.Models;




namespace MusicHubMaster.Controllers
{
    public class PerformersController : Controller
    {
        private readonly IPerformerService _service;

        public PerformersController(IPerformerService service)
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

            var performer = await _service.Get(id);

            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Country,Pseudonym")] PerformerModel performer)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(performer);
                return RedirectToAction(nameof(Index));
            }

            return View(performer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performer = await _service.Get(id);

            if (performer == null)
            {
                return NotFound();
            }
            return View(performer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Country,Pseudonym")] PerformerModel performer)
        {
            if (id != performer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(performer);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformerExists(performer.Id))
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
            return View(performer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performer = await _service.Get(id);

            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PerformerExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
