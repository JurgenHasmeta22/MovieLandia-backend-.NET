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
    internal class EpisodeDomain : DomainBase, IEpisodeDomain
    {
        public EpisodeDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IEpisodeRepository episodeRepository => _unitOfWork.GetRepository<IEpisodeRepository>();

        public IList<EpisodeDTO> GetAllEpisodes()
        {
            IEnumerable<Episode> episodes = episodeRepository.GetAllEpisodes();
            var episodesFinal = _mapper.Map<IList<EpisodeDTO>>(episodes);
            return episodesFinal;
        }
        public EpisodeDTO GetEpisodeById(int id)
        {
            Episode episode = episodeRepository.GetEpisodeById(id);
            var episodeFinal = _mapper.Map<EpisodeDTO>(episode);
            return episodeFinal;
        }

    }
}
