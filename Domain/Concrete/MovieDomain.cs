using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.MovieDTO;
using Entities.Models;
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

        private IMoviesRepository movieRepository => _unitOfWork.GetRepository<IMoviesRepository>();

        public IList<MovieDTO> GetAllMovies()
        {
            IEnumerable<Movie> movies = movieRepository.GetAllMovies();
            var moviesFinal = _mapper.Map<IList<MovieDTO>>(movies);
            return moviesFinal;
        }

        public MovieDTO GetMovieById(int id)
        {
            Movie movie = movieRepository.GetMovieById(id);
            var movieFinal = _mapper.Map<MovieDTO>(movie);
            return movieFinal;
        }
    }
}
