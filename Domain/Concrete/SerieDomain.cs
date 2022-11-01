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
    internal class SerieDomain : DomainBase, ISerieDomain
    {
        public SerieDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private ISerieRepository serieRepository => _unitOfWork.GetRepository<ISerieRepository>();

        public IList<SerieDTO> GetAllSeries()
        {
            IEnumerable<Serie> series = serieRepository.GetAllSeries();
            var seriesFinal = _mapper.Map<IList<SerieDTO>>(series);
            return seriesFinal;
        }

        public SerieDTO GetSerieById(int id)
        {
            Serie serie = serieRepository.GetSerieById(id);
            var serieFinal = _mapper.Map<SerieDTO>(serie);
            return serieFinal;
        }

        public SerieDTO AddSerie(SeriePostDTO serie)
        {
            var serieEntity = _mapper.Map<Serie>(serie);
            var serieFinal = serieRepository.Add(serieEntity);

            var serieToReturn = _mapper.Map<SerieDTO>(serieFinal);
            _unitOfWork.Save();

            return serieToReturn;
        }

        public void DeleteSerieById(int id)
        {
            try
            {
                var serie = serieRepository.GetById(id);

                if (serie is null)
                    throw new Exception();

                var serieEpisodes = serie.Episodes;

                foreach (var serieEpisode in serieEpisodes)
                {
                    serieEpisodes.Remove(serieEpisode);
                }

                serieRepository.Remove(id);
                _unitOfWork.Save();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSerieByIdPut(int id, SeriePostDTO serie)
        {
            var serieEntity = serieRepository.GetById(id);

            if (serieEntity is null)
                throw new Exception();

            serieEntity = _mapper.Map<SeriePostDTO, Serie>(serie, serieEntity);

            serieRepository.Update(serieEntity);
            _unitOfWork.Save();
        }

    }
}
