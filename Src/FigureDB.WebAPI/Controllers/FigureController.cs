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
        private readonly IFigureTagService _figureTagService;
        private readonly IFigureTypeService _figureTypeService;
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public FigureController(IFigureService service, IMapper mapper, IFigureTagService figureTagService, INewsService newsService, IFigureTypeService figureTypeService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _figureTagService = figureTagService ?? throw new ArgumentNullException(nameof(figureTagService));
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _figureTypeService = figureTypeService ?? throw new ArgumentNullException(nameof(figureTypeService));
        }

        // GET: api/<FigureController>
        [HttpGet]
        public async Task<PaginationDTO<FigureDTO>> Get([FromQuery] ParametersViewModel viewModel)
        {
            var figures = await _service.GetFigures(viewModel.Index, viewModel.Size);
            return figures;
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
            var figure = _mapper.Map<Figure>(viewmodel);
            var news = new News
            {
                Content = figure.CHNName,
                Title = "条目创建",
                FigureId = figure.Id
            };
            if (await _service.CreateFigure(figure)
                && await _figureTagService.CreateFigureTags(figure.Id, viewmodel.Tags)
                && await _newsService.CreateNews(news)
                && await _figureTypeService.CreateFigureType(figure.Id,viewmodel.FigureType))
            {
                var figureDTO = _mapper.Map<FigureDTO>(figure);
                return new UnifyResponseDto(
                    Model.Enum.StatusCode.Sucess,
                    figureDTO
                    );
            }
            return UnifyResponseDto.Fail();
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
