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
    internal class MoviesDomain : DomainBase, IMoviesDomain
    {
        public MoviesDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IMoviesRepository moviesRepository => _unitOfWork.GetRepository<IMoviesRepository>();

        public IList<MoviesDTO> GetAllMovies()
        {
            IEnumerable<Movie> movies = moviesRepository.GetAllMovies();
            var moviesFinal = _mapper.Map<IList<MoviesDTO>>(movies);
            return moviesFinal;
        }

        public MoviesDTO GetMovieById(int id)
        {
            Movie movie = moviesRepository.GetMovieById(id);
            var movieFinal = _mapper.Map<MoviesDTO>(movie);
            return movieFinal;
        }
    }
}
