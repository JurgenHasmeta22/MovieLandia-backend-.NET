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
    internal class SerieRepository : BaseRepository<Serie, int>, ISerieRepository
    {
        public SerieRepository(MovieLandiaContext dbContext) : base(dbContext)
        {
        }
        public IList<Serie> GetAllSeries()
        {
            return context.Include(x => x.Episodes).ToList();
        }
        public Serie GetSerieById(int id)
        {
            return context.Include(x => x.Episodes).ToList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
