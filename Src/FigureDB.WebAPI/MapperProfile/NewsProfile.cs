using AutoMapper;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.MapperProfile
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>()
                .ForMember(dest => dest.CoverImagePath, opt => opt
                .MapFrom(
                    src => 
                    src.Figure.FigureImages
                    .Where(fi => fi.FigureImageType == Model.Enum.FigureImageType.Cover)
                    .FirstOrDefault().Image.Path)
                    );
        }
    }
}
