using AutoMapper;
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
        private readonly IFigureTypeService _service;
        private readonly IMapper _mapper;

        public FigureTypeController(IFigureTypeService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<FigureTypeController>
        [HttpGet]
        public async Task<List<FigureType>> Get()
        {
            return await _service.GetFigureTypes(); ;
        }

        // GET api/<FigureTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FigureTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FigureTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FigureTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
