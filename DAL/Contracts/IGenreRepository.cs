using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IGenreRepository : IRepository<Genre, int>
    {
        IList<Genre> GetAllGenres();
        public Genre GetGenreById(int id);
    }
}
