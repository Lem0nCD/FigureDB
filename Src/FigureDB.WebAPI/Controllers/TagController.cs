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
    public class TagController : ControllerBase
    {
        private readonly ITagService _service;
        private readonly IMapper _mapper;

        public TagController(ITagService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<TagController>
        [HttpGet]
        public async Task<List<Tag>> Get()
        {
            return await _service.GetAllTag();
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public async Task<List<Tag>> Get(Guid id)
        {
            return await _service.GetFigureTagsByFigureId(id);
        }

        // POST api/<TagController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
