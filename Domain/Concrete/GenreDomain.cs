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

        public GenreDTO AddGenre(GenrePostDTO genre)
        {
            var genreEntity = _mapper.Map<Genre>(genre);
            var genreFinal = genreRepository.Add(genreEntity);

            var genreToReturn = _mapper.Map<GenreDTO>(genreFinal);
            _unitOfWork.Save();

            return genreToReturn;
        }

        public void DeleteGenreById(int id)
        {
            try
            {
                var genre = genreRepository.GetById(id);

                if (genre is null)
                    throw new Exception();

                var genreMovies = genre.MovieGenres;

                foreach (var genreMovie in genreMovies)
                {
                    genreMovies.Remove(genreMovie);
                }

                genreRepository.Remove(id);
                _unitOfWork.Save();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateGenreByIdPut(int id, GenrePostDTO genre)
        {
            var genreEntity = genreRepository.GetById(id);

            if (genreEntity is null)
                throw new Exception();

            genreEntity = _mapper.Map<GenrePostDTO, Genre>(genre, genreEntity);

            genreRepository.Update(genreEntity);
            _unitOfWork.Save();
        }

    }
}
