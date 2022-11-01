using AutoMapper;
using DTO.MovieDTO;
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
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieWithoutMovieGenreDTO>().ReverseMap();
            CreateMap<MovieGenre, MovieGenreDTO>().ReverseMap();
            CreateMap<MovieGenre, MovieGenreWithoutGenreDTO>().ReverseMap();
            CreateMap<MovieGenre, MovieGenreWithoutMovieDTO>().ReverseMap();
            CreateMap<Genre, GenreWithoutMovieGenreDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Serie, SerieDTO>().ReverseMap();
            CreateMap<Serie, SerieWithoutEpisodesDTO>().ReverseMap();
            CreateMap<Episode, EpisodeInSerieDTO>().ReverseMap();
            CreateMap<Episode, EpisodeDTO>().ReverseMap();
        }
    }
}
