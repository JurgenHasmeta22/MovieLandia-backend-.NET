using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.MovieDTO;
using Entities.Models;
using Helpers.RequestFeatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class MovieDomain : DomainBase, IMovieDomain
    {
        public MovieDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IMovieRepository movieRepository => _unitOfWork.GetRepository<IMovieRepository>();

        public IList<MovieDTO> GetAllMovies(MovieParameters movieParameters)
        {
            IEnumerable<Movie> movies = movieRepository.GetAllMovies(movieParameters);
            var moviesFinal = _mapper.Map<IList<MovieDTO>>(movies);
            return moviesFinal;
        }

        public MovieDTO GetMovieById(int id)
        {
            Movie movie = movieRepository.GetMovieById(id);
            var movieFinal = _mapper.Map<MovieDTO>(movie);
            return movieFinal;
        }

        public MovieDTO AddMovie(MoviePostDTO movie)
        {
            var movieEntity = _mapper.Map<Movie>(movie);
            var movieFinal = movieRepository.Add(movieEntity);

            var movieToReturn = _mapper.Map<MovieDTO>(movieFinal);
            _unitOfWork.Save();

            return movieToReturn;
        }

        public void DeleteMovieById(int id)
        {
            try
            {
                var movie = movieRepository.GetById(id);

                if (movie is null)
                    throw new Exception();

                var movieGenres = movie.MovieGenres;

                foreach (var movieGenre in movieGenres)
                {
                    movieGenres.Remove(movieGenre);
                }

                movieRepository.Remove(id);
                _unitOfWork.Save();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMovieByIdPut(int id, MoviePostDTO movie)
        {
            var movieEntity = movieRepository.GetById(id);

            if (movieEntity is null)
                throw new Exception();

            movieEntity = _mapper.Map<MoviePostDTO, Movie>(movie, movieEntity);

            movieRepository.Update(movieEntity);
            _unitOfWork.Save();
        }

        /*
        public void UpdateMovieByIdPatch(int id, JsonPatchDocument patchDoc)
        {
            var project = movieRepository.GetById(id);

            if (project is null)
                throw new Exception();

            patchDoc.ApplyTo(project);
            _unitOfWork.Save();
        }
        */

    }
}
