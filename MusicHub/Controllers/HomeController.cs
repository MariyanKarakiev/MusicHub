using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicHubMaster.Data;
using MusicHubMaster.Infrastructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicHub.Core.Contracts;

namespace MusicHubMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ISongService _songService;
        public IWriterService _writerService;
        public IAlbumService _albumService;
        public IPerformerService _performerService;

        public HomeController(ILogger<HomeController> logger, ISongService songService,
         IWriterService writerService, IAlbumService albumService, IPerformerService performerService)
        {
            _logger = logger;
            _albumService = albumService;
            _writerService = writerService;
            _songService = songService;
            _performerService = performerService;
        }

        public async Task<IActionResult> Index()
        {
            var stats = new StatisticsModel
            {
                SongsCount = await _songService.Count(),
                PerformersCount = await _performerService.Count(),
                AlbumsCount = await _albumService.Count(),
                WritersCount = await _writerService.Count()
            };


            ViewData["Stats"] = stats;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
