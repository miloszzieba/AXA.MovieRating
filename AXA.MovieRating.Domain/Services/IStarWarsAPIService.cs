using AXA.MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AXA.MovieRating.Domain.Services
{
    public interface IStarWarsAPIService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(long id);
    }
}
