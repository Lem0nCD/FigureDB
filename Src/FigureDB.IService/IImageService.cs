using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FigureDB.IService
{
    public interface IImageService
    {
        public Task<bool> CreateImage(string basePath);
    }
}
