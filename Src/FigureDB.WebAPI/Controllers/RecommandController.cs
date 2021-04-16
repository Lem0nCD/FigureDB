using AutoMapper;
using FigureDB.IService;
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
    public class RecommandController : ControllerBase
    {
        private readonly IFigureService _service;
        private readonly IFigureTypeService _figureTypeService;
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public RecommandController(IFigureService service, IMapper mapper, INewsService newsService, IFigureTypeService figureTypeService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _figureTypeService = figureTypeService ?? throw new ArgumentNullException(nameof(figureTypeService));
        }
        // GET: api/<RecommandController>
        [HttpGet]
        //public async IEnumerable<string> Get()
        //{
        //    List<List<Model.Entities.FigureType>> typeList = await _figureTypeService.GetRecommandFigure();

        //}

        // GET api/<RecommandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecommandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecommandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecommandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
