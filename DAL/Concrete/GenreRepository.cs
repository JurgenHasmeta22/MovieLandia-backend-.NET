using DAL.Contracts;
using Entities.Models;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class GenreRepository : BaseRepository<Genre, int>, IGenreRepository
    {
        public GenreRepository(MovieLandiaContext dbContext) : base(dbContext)
        {
        }
        public IList<Genre> GetAllGenres()
        {
            return context.Include(x => x.MovieGenres)
                .ThenInclude(x => x.Movie)
                .ToList();
        }
        public Genre GetGenreById(int id)
        {
            return context.Include(x => x.MovieGenres)
                .ThenInclude(x => x.Movie)
                .ToList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
