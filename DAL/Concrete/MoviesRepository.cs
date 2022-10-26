using DAL.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class MoviesRepository : BaseRepository<Movie, int>, IMoviesRepository
    {
        public MoviesRepository(MovieLandiaContext dbContext) : base(dbContext)
        {
        }

        public IList<Movie> GetAllMovies()
        {
            return context.Include(x => x.MovieGenres)
                    .ThenInclude(x => x.Genre)
                    .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return context.Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .ToList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
