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
        private readonly IFigureTypeService _figureTypeService;
        private readonly IMapper _mapper;

        public FigureImageController(IFigureImageService service, IMapper mapper, IFigureTypeService figureTypeService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _figureTypeService = figureTypeService ?? throw new ArgumentNullException(nameof(figureTypeService));
        }

        // GET: api/<FigureImageController>
        [HttpGet]
        public async Task<List<FigureImageDTO>> Get()
        {
            List<FigureImage> result = new List<FigureImage>();
            var biglist = await _figureTypeService.GetRecommandFigure();
            //var list1 = biglist[0];
            //var list2 = biglist[1];
            //var list3 = biglist[2];
            //var list4 = biglist[3];
            //var list5 = biglist[4];
            foreach (var innerList in biglist)
            {
                foreach (var item in innerList)
                {
                    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
                }
            }
            //foreach (var item in list1)
            //{
            //    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
            //}
            //foreach (var item in list2)
            //{
            //    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
            //}
            //foreach (var item in list3)
            //{
            //    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
            //}
            //foreach (var item in list4)
            //{
            //    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
            //}
            //foreach (var item in list5)
            //{
            //    result.Add(await _service.GetFigureCoverImageByFigureId(item.FigureId));
            //}

            var list  = _mapper.Map<List<FigureImageDTO>>(result);
            return list;
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
