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
    public class OriginController : ControllerBase
    {
        private readonly IOriginService _service;
        private readonly IMapper _mapper;

        public OriginController(IOriginService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<OriginController>
        [HttpGet]
        public async Task<List<Origin>> Get()
        {
            return await _service.GetAllOrigin();

        }

        // GET api/<OriginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OriginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OriginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OriginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
