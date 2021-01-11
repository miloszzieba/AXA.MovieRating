using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.MVC.DTOs
{
    public class MovieDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double AverageRating { get; set; }
        //Other properties if we want to show them
    }
}
