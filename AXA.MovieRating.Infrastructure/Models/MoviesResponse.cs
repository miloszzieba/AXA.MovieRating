using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA.MovieRating.Infrastructure.Models
{
    public class MoviesResponse
    {
        public int Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<MovieResponse> Results { get; set; }
    }
}
