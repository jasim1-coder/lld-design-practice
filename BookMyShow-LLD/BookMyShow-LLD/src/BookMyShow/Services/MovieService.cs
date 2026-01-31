using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Services
{
    public class MovieService
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
            new Movie(1, "Inception"),
            new Movie(2, "Interstellar")            };
        }
    }
}
