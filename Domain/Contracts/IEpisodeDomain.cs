using DTO.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Contracts
{
    public interface IEpisodeDomain
    {
        public IList<EpisodeDTO> GetAllEpisodes();
        public EpisodeDTO GetEpisodeById(int id);
        EpisodeDTO AddEpisode(EpisodePostDTO episode);
        void UpdateEpisodeByIdPut(int id, EpisodePostDTO episode);
        void DeleteEpisodeById(int id);
    }
}
