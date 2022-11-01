using DTO.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Contracts
{
    public interface ISerieDomain
    {
        public IList<SerieDTO> GetAllSeries();
        public SerieDTO GetSerieById(int id);
        SerieDTO AddSerie(SeriePostDTO serie);
        void UpdateSerieByIdPut(int id, SeriePostDTO serie);
        void DeleteSerieById(int id);
    }
}
