using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.WebAPI.ViewModels
{
    public class OfferViewModel
    {
        public decimal Price { get; set; }
        public Guid FigureId { get; set; }
    }
}
