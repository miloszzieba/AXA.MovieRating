using AXA.MovieRating.MVC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.MVC.Models
{
    public class HomeViewModel
    {
        public IEnumerable<MovieDTO> Movies { get; set; }
    }
}
