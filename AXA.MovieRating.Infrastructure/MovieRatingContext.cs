using AXA.MovieRating.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AXA.MovieRating.Infrastructure
{
    public class MovieRatingContext : DbContext
    {
        public MovieRatingContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Opinion> Opinions { get; set; }
    }
}
