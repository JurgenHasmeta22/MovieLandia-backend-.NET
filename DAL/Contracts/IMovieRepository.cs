using Entities.Models;
using Helpers.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IMovieRepository : IRepository<Movie, int>
    {
        PagedList<Movie> GetAllMovies(MovieParameters movieParameters);
        Movie GetMovieById(int id);
    }
}
