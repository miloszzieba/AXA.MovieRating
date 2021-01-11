using AXA.MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA.MovieRating.Domain.Services
{
    public interface IMoviesService
    {
        Task Rate(long movieId, short rating);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovie(long id);
    }
}
