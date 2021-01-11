using AXA.MovieRating.Domain.Services;
using AXA.MovieRating.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMoviesService _moviesService;

        public HomeController(ILogger<HomeController> logger,
            IMoviesService moviesService)
        {
            this._logger = logger;
            this._moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await this._moviesService.GetAllMovies();
            var viewModel = new HomeViewModel()
            {
                Movies = movies.Select(x => new DTOs.MovieDTO
                {
                    Id = x.Id,
                    AverageRating = x.AverageRating,
                    Title = x.Title
                }).ToList()
            };
            return View(viewModel);
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
