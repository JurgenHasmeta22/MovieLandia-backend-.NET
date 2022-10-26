using DAL.Contracts;
using Entities.Models;
using LamarCodeGeneration.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class EpisodeRepository : BaseRepository<Episode, int>, IEpisodeRepository
    {
        public EpisodeRepository(MovieLandiaContext dbContext) : base(dbContext)
        {
        }
        public IList<Episode> GetAllEpisodes()
        {
            return context.Include(x => x.Serie).ToList();
        }
        public Episode GetEpisodeById(int id)
        {
            return context.Include(x => x.Serie)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
