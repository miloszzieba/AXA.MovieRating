using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA.MovieRating.Models
{
    public class Opinion
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public short Rating { get; set; }
    }
}
