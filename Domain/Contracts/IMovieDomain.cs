using DTO.MovieDTO;
using Entities.Models;
using Helpers.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
/* using Microsoft.AspNetCore.JsonPatch; */

namespace Domain.Contracts
{
    public interface IMovieDomain
    {
        public IList<MovieDTO> GetAllMovies(MovieParameters movieParameters);
        public MovieDTO GetMovieById(int id);
        MovieDTO AddMovie(MoviePostDTO movie);
        void UpdateMovieByIdPut(int id, MoviePostDTO movie);
        void DeleteMovieById(int id);
        /* void UpdateMovieByIdPatch(int id, JsonPatchDocument patchDoc); */
    }
}
