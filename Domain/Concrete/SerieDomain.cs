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
    }
}
