using AutoMapper;
using DTO.MovieDTO;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
      
        public GeneralProfile()
        {
           CreateMap<Movie, MoviesDTO>().ReverseMap();
           CreateMap<MovieGenre, MovieGenreDTO>().ReverseMap();
           CreateMap<Genre, GenreDTO1>().ReverseMap();



        }

        
        

    }
}
