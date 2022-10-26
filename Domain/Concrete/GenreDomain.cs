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
    internal class GenreDomain : DomainBase, IGenreDomain
    {
        public GenreDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IGenreRepository genreRepository => _unitOfWork.GetRepository<IGenreRepository>();

        public IList<GenreDTO> GetAllGenres()
        {
            IEnumerable<Genre> genres = genreRepository.GetAllGenres();
            var genreFinal = _mapper.Map<IList<GenreDTO>>(genres);
            return genreFinal;
        }
        public GenreDTO GetGenreById(int id)
        {
            Genre genre = genreRepository.GetGenreById(id);
            var genreFinal = _mapper.Map<GenreDTO>(genre);
            return genreFinal;
        }
    }
}
