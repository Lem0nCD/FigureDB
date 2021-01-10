using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Service
{
    public class FigureTagService : IFigureTagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    }
}
