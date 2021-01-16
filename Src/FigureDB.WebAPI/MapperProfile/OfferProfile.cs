using AutoMapper;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.MapperProfile
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDTO>()
                .ForMember(dest => dest.Shopname, opt => opt.MapFrom(src => src.Shop.Name))
                .ForMember(dest => dest.HomePage, opt => opt.MapFrom(src => src.Shop.Homepage));
        }
    }
}
