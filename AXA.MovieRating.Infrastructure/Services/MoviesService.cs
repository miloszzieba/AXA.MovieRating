using AXA.MovieRating.Domain.Services;
using AXA.MovieRating.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA.MovieRating.Infrastructure.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IStarWarsAPIService _starWarsAPIService;
        private readonly MovieRatingContext _movieRatingContext;

        public MoviesService(IStarWarsAPIService starWarsAPIService,
            MovieRatingContext movieRatingContext)
        {
            this._starWarsAPIService = starWarsAPIService;
            this._movieRatingContext = movieRatingContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await this._starWarsAPIService.GetMovies();
            var movieRatings = await _movieRatingContext.Opinions
                .GroupBy(x => x.MovieId)
                .Select(x => new
                {
                    MovieId = x.Key,
                    AverageRating = x.Average(y => y.Rating)
                })
                .ToListAsync();

            return movies.GroupJoin(movieRatings, x => x.Id, x => x.MovieId, (x, y) =>
            {
                x.AverageRating = y.FirstOrDefault()?.AverageRating ?? 0;
                return x;
            });
        }

        public async Task<Movie> GetMovie(long id)
        {
            var movie = await this._starWarsAPIService.GetMovie(id);
            movie.AverageRating = _movieRatingContext.Opinions
                .Where(x => x.MovieId == id)
                .Average(x => x.Rating);

            return movie;
        }

        public async Task Rate(long movieId, short rating)
        {
            await this._movieRatingContext.Opinions.AddAsync(new Opinion()
            {
                MovieId = movieId,
                Rating = rating
            });
        }
    }
}
