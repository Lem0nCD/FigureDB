using FigureDB.Model.DTO;
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
            var file = viewModel.file;
            if (file != null && file.Length > 0)
            {
                string index = "fail";
                string imageId = Guid.NewGuid().ToString();
                switch (viewModel.imageType)
                {
                    case "figure":
                        index = viewModel.imageType;
                        break;
                    case "user":
                        index = viewModel.imageType;
                        break;
                    default:
                        break;
                }
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", index, viewModel.id, imageId);
                long size = file.Length;
                string[] contentTypeStrings = file.ContentType.Split('/');
                if (contentTypeStrings.FirstOrDefault() == "image")
                {
                    switch (contentTypeStrings.Last())
                    {
                        case "jpeg":
                            path = path + ".jpg";
                            break;
                        case "png":
                            path = path + ".png";
                            break;
                    }
                    using (var stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return new UnifyResponseDto(Model.Enum.StatusCode.Sucess, new
                    {
                        size = size,
                        id = viewModel.id,
                        imageId = imageId,
                    });
                }
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
