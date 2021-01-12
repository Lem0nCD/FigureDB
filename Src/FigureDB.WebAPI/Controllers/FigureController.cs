using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using FigureDB.WebAPI.ViewModels;
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
    public class FigureController : ControllerBase
    {
        private readonly IFigureService _service;
        private readonly IMapper _mapper;

        public FigureController(IFigureService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<FigureController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FigureController>/5
        [HttpGet("{id}")]
        public async Task<FigureDTO> Get(Guid id)
        {
            return await _service.GetFigure(id);
        }

        // POST api/<FigureController>
        [HttpPost]
        public async Task<UnifyResponseDto> Post(CreateFigureViewModel viewmodel)
        {
            var temp = _mapper.Map<Figure>(viewmodel);
            await _service.CreateFigure(temp);
            return new UnifyResponseDto(
                Model.Enum.StatusCode.Sucess,
                new
                {
                    figureId = temp.Id.ToString(),
                });
        }

        // PUT api/<FigureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FigureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
