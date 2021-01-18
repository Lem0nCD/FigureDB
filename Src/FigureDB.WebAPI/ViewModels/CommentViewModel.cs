using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.ViewModels
{
    public class CommentViewModel
    {
        public Guid FigureId { get; set; }
        public string Content { get; set; }
    }
}
