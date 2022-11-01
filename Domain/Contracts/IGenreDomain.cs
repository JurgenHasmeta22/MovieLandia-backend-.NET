using DTO.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Contracts
{
    public interface IGenreDomain
    {
        public IList<GenreDTO> GetAllGenres();
        public GenreDTO GetGenreById(int id);
        GenreDTO AddGenre(GenrePostDTO genre);
        void UpdateGenreByIdPut(int id, GenrePostDTO genre);
        void DeleteGenreById(int id);
    }
}
