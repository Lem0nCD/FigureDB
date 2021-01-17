using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigureImageController : ControllerBase
    {
        private readonly IFigureImageService _service;
        private readonly IMapper _mapper;

        public FigureImageController(IFigureImageService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<FigureImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FigureImageController>/5
        [HttpGet("{id}")]
        public async Task<List<FigureImageDTO>> Get(Guid id)
        {
            List<FigureImage> figureImage = await _service.GetFigureImageByFigureId(id);
            return _mapper.Map<List<FigureImageDTO>>(figureImage);
        }

        // POST api/<FigureImageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FigureImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FigureImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
