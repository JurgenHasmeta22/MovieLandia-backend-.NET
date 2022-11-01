using DAL.Contracts;
using Entities.Models;
using Helpers.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class MovieRepository : BaseRepository<Movie, int>, IMovieRepository
    {
        public MovieRepository(MovieLandiaContext dbContext) : base(dbContext)
            {
        }

        public PagedList<Movie> GetAllMovies(MovieParameters movieParameters)
        {
            return PagedList<Movie>.ToPagedList(
                    context.Include(x => x.MovieGenres).ThenInclude(x => x.Genre),
                    movieParameters.PageNumber,
                    movieParameters.PageSize
                );
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
