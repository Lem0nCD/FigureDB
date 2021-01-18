using FigureDB.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.WebAPI.ViewModels
{
    public class FavoriteViewModel
    {
        public FavoriteType Type { get; set; }
        public Guid FigureId { get; set; }
    }
}
