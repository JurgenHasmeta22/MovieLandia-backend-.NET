using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IEpisodeRepository : IRepository<Episode, int>
    {
        IList<Episode> GetAllEpisodes();
        public Episode GetEpisodeById(int id);
    }
}
