using AutoMapper;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigureTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFigureTypeService _service;

        public FigureTypeController(IMapper mapper, IFigureTypeService service)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET: api/<FigureTypeController>
        [HttpGet]
        public async Task<List<FigureType>> Get()
        {
            return await _service.GetAllFigureType();
        }

        // GET api/<FigureTyoeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
