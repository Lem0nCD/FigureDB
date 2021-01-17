using AutoMapper;
using FigureDB.IService;
using FigureDB.Model.DTO;
using FigureDB.Model.Entities;
using FigureDB.Model.Enum;
using FigureDB.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FigureDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;
        private readonly IFigureImageService _figureImageService;
        private readonly IMapper _mapper;

        public ImageController(IImageService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<ImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImageController>
        //[RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        //[RequestSizeLimit(long.MaxValue)]
        [HttpPost]
        public async Task<UnifyResponseDto> Post([FromForm] UploadImageViewModel viewModel)
        {
            var file = viewModel.File;
            if (file != null && file.Length > 0)
            {
                Image image = new Image();
                string typeIndex = "fail";
                switch (viewModel.ImageType)
                {
                    case "figure":
                        typeIndex = viewModel.ImageType;
                        break;
                    case "user":
                        typeIndex = viewModel.ImageType;
                        break;
                    default:
                        break;
                }
                string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", typeIndex, viewModel.ParentId);
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }
                string fullPath = Path.ChangeExtension(Path.Combine(basePath, image.Id.ToString()), Path.GetExtension(file.FileName));
                try
                {
                    using var stream = System.IO.File.Create(fullPath);
                    await file.CopyToAsync(stream);

                }
                catch (Exception)
                {
                    throw;
                }
                await _service.CreateImage(fullPath);
                if (typeIndex == "figure")
                {
                    await _figureImageService.CreateFigureImage(Guid.Parse(viewModel.ParentId), image.Id, viewModel.FigureImageType);
                }
                return UnifyResponseDto.Sucess();
            }
            return UnifyResponseDto.Fail();
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
