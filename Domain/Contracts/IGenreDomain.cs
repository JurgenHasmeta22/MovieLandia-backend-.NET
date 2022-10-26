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
    }
}
