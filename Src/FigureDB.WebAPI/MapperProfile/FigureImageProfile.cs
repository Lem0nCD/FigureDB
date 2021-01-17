using AutoMapper;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.MapperProfile
{
    public class FigureImageProfile : Profile
    {
        public FigureImageProfile()
        {
            CreateMap<FigureImage, FigureImageDTO>()
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Image.Path))
                .ForMember(dest => dest.FigureImageType, opt => opt.MapFrom(src => src.FigureImageType.ToString()));

        }
    }
}
