using System;

namespace AXA.MovieRating.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double AverageRating { get; set; }
        //Other properties we want to store
    }
}
