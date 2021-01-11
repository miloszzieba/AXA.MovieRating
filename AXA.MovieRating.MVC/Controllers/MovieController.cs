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
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMoviesService _moviesService;

        public MovieController(ILogger<MovieController> logger,
            IMoviesService moviesService)
        {
            this._logger = logger;
            this._moviesService = moviesService;
        }

        public async Task<IActionResult> Index(long id)
        {
            var movie = await this._moviesService.GetMovie(id);
            var viewModel = new MovieViewModel()
            {
              
            };
            return View(viewModel);
        }
    }
}
