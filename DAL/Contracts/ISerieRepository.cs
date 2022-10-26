using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ISerieRepository : IRepository<Serie, int>
    {
        IList<Serie> GetAllSeries();
        Serie GetSerieById(int id);
    }
}
