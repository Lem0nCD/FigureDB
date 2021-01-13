using System;
using System.Collections.Generic;

namespace FigureDB.Model.DTO
{
    public class PaginationDTO<T> where T : class
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }

        public PaginationDTO(int total, List<T> data)
        {
            Total = total;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public PaginationDTO()
        {

        }
    }
}
