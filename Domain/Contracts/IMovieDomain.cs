using DTO.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Contracts
{
    public interface IMovieDomain
    {
        public IList<MovieDTO> GetAllMovies();
        public MovieDTO GetMovieById(int id);
    }
}
