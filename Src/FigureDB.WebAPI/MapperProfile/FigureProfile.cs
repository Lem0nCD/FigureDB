﻿using AutoMapper;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using FigureDB.WebAPI.ViewModels;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.MapperProfile
{
    public class FigureProfile : Profile
    {
        public FigureProfile()
        {
            CreateMap<Figure, FigureDTO>()
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.CHNName))
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.Origin.CHNName))
                .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Published.CHNName))
                .ForMember(dest => dest.Series, opt => opt.MapFrom(src => src.Series.CHNName))
                .ForMember(dest => dest.Character, opt => opt.MapFrom(src => src.Character.CHNName))
                .ForMember(dest => dest.CoverImagePath, opt => opt.MapFrom(src => src.FigureImages
                .Where(fi => fi.FigureImageType == Model.Enum.FigureImageType.Cover)
                .FirstOrDefault().Image.Path));
            CreateMap<CreateFigureViewModel, Figure>();
        }
    }
}
